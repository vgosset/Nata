using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
  [SerializeField] private GameObject target;
  [SerializeField] private List<GameObject> arrivals = new List<GameObject>();
  [SerializeField] private GameObject shakeCamera;
  [SerializeField] private GameObject joysticMov;
  [SerializeField] private GameObject joystickShoot;
  [SerializeField] private Vector3 offset;
  [SerializeField] private Vector3 offsetLevel2;
  [SerializeField] private float transitionSpeed;
  [SerializeField] private float rotationSpeed;
  [SerializeField] private List<Transform> LevelDestination = new List<Transform>();

  private Vector3 dirNormalized;
  private bool transitionRotOk;
  private bool transitionPosOk;
  private LevelState  levelState;
  private TransitionState  transitionState;

  enum LevelState
  {
    LEVEL_1,
    LEVEL_2,
    LEVEL_3,
    LEVEL_4,
    TRANSITION
  };
  enum TransitionState
  {
    TRANSITION_ON,
    TRANSITION_OFF,
  };

  void Start()
  {
    levelState = LevelState.LEVEL_1;
    transitionState = TransitionState.TRANSITION_OFF;
  }

  void LateUpdate()
  {
    if (levelState == LevelState.LEVEL_1 && transitionState == TransitionState.TRANSITION_OFF)
      transform.position = new Vector3 (target.transform.position.x + offset.x, transform.position.y, target.transform.position.z + offset.z);
    if (levelState == LevelState.LEVEL_2 && transitionState == TransitionState.TRANSITION_ON)
    {
      Transition();
    }
    if (levelState == LevelState.LEVEL_2 && transitionState == TransitionState.TRANSITION_OFF)
    {
      transform.position = new Vector3 (transform.position.x , transform.position.y, target.transform.position.z + offset.z);
    }
  }

  private void Transition()  {
    if(Vector3.Distance(LevelDestination[0].transform.position, transform.position) <= 0.1f)
    {
      transform.position = LevelDestination[0].transform.position;
      transitionPosOk = true;
    }
    else
    {
      offset =  Vector3.Lerp(offset, offsetLevel2, Time.deltaTime * transitionSpeed);
      transform.position = transform.position + dirNormalized * transitionSpeed * Time.deltaTime;
    }
    if(Quaternion.Angle(transform.rotation, LevelDestination[0].transform.rotation) <= 0)
    {
      transform.rotation = LevelDestination[0].transform.rotation;
      transitionRotOk = true;
    }
    if (transitionPosOk && transitionRotOk)
    {
      transitionState = TransitionState.TRANSITION_OFF;
      target.GetComponent<PlayerBehavior>().SetLevel((int)levelState);
    }

    else
    {
      Vector3 angleTarget = new Vector3(
        Mathf.LerpAngle(transform.rotation.eulerAngles.x, LevelDestination[(int)levelState -1].transform.rotation.eulerAngles.x, Time.deltaTime * rotationSpeed),
        Mathf.LerpAngle(transform.rotation.eulerAngles.y, LevelDestination[(int)levelState -1].transform.rotation.eulerAngles.y, Time.deltaTime * rotationSpeed),
        Mathf.LerpAngle(transform.rotation.eulerAngles.z, LevelDestination[(int)levelState -1].transform.rotation.eulerAngles.z, Time.deltaTime * rotationSpeed ));
      transform.eulerAngles = angleTarget;
    }
  }

  public  void SetLevel(int level)
  {
    levelState = (LevelState)level;
    transitionState = TransitionState.TRANSITION_ON;
    dirNormalized = (LevelDestination[0].transform.position - transform.position).normalized;
    transitionRotOk = false;
    transitionPosOk = false;
    arrivals[0].GetComponent<Door>().ChangeState();
    arrivals[1].GetComponent<Door>().ChangeState();
  }
  public bool IsInTransition()
  {
    if (transitionState == TransitionState.TRANSITION_ON)
      return true;
    return false;
  }
}
