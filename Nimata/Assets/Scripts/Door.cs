using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform rayTarget;
    [SerializeField] private GameObject target;
    private bool open = true;


    void Start()
    {

    }
    void Update()
    {
      // RaycastHit hit;
      // Debug.DrawRay(transform.position,  Vector3.forward, Color.green , 1f);
      // if(Physics.Raycast(transform.position, Vector3.forward, out hit, 0.2f))
      // {
      //   Debug.Log(hit.transform.tag);
      //  if(hit.transform.tag == "Player")
      //  {
      //    Debug.Log("FDFDF");
      //  }
      // }
    }
    void FixedUpdate()
    {
        if (!open)
          transform.position = Vector3.MoveTowards(transform.position,  target.transform.position, 2 * Time.deltaTime);
    }
    public void ChangeState()
    {
      open = !open;
    }
}
