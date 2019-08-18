using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    enum ControlType
    {
      LEVEL_1,
      LEVEL_2,
      LEVEL_3,
      LEVEL_4,
    };

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpot;
    public float speed;
    public VariableJoystick variableJoystick;
    private ControlType  controlType;
    public VariableJoystick variableJoystickShoot;
    public Rigidbody rb;
    [SerializeField] float fireRate;
    [SerializeField] float projectileSpeed;
    private float fireRateTimer;
    private bool canFire = true;
    private Vector3 direction;
    private Vector3 directionShoot;

    void Start()
    {
      controlType = ControlType.LEVEL_1;
    }

    public void Update()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer > fireRate)
            canFire = true;
    }
    public void FixedUpdate()
    {
      if (!Camera.main.GetComponent<MainCamera>().IsInTransition())
      {
        if (controlType == ControlType.LEVEL_1)
        {
          direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
          directionShoot = Vector3.forward * variableJoystickShoot.Vertical + Vector3.right * variableJoystickShoot.Horizontal;
        }
        if (controlType == ControlType.LEVEL_2)
        {
          direction = Vector3.forward * variableJoystick.Horizontal + Vector3.left * variableJoystick.Vertical;
          directionShoot = Vector3.forward * variableJoystickShoot.Horizontal + Vector3.left * variableJoystickShoot.Vertical;
        }
        rb.velocity = direction * speed;
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);
        if (directionShoot != Vector3.zero)
        {
            if (canFire)
                fire(directionShoot);
            transform.rotation = Quaternion.LookRotation(directionShoot);
        }
      }
      else
        rb.velocity = Vector3.zero;

    }
    private void fire(Vector3 dir)
    {
        canFire = false;
        fireRateTimer = 0;
        GameObject tmp = Instantiate(bullet, bulletSpot.position, Quaternion.LookRotation(dir));
        tmp.GetComponent<BulletBehavior>().SetSpeed(projectileSpeed);
    }
    public void SetLevel(int level)
    {
      controlType = (ControlType)level;
    }
    private void OnTriggerEnter(Collider other)
    {
      if (other.transform.tag == "EnemyBullets" || other.transform.tag == "Enemies")
      {
          transform.GetComponent<PlayerLife>().PlayerGetHit();
          Destroy(other.transform.gameObject);
      }
      if (other.transform.tag == "Level1End")
      {
        Camera.main.GetComponent<MainCamera>().SetLevel(1);
        Destroy(other.transform.gameObject);
      }
    }
}
