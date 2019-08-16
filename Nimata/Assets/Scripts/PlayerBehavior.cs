using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpot;
    public float speed;
    public VariableJoystick variableJoystick;
    public VariableJoystick variableJoystickShoot;
    public Rigidbody rb;
    [SerializeField] float fireRate;
    [SerializeField] float projectileSpeed;
    private float fireRateTimer;
    private bool canFire = true;
    public void Update()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer > fireRate)
            canFire = true;
    }
    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        Vector3 directionShoot = Vector3.forward * variableJoystickShoot.Vertical + Vector3.right * variableJoystickShoot.Horizontal;
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
    private void fire(Vector3 dir)
    {
        Debug.Log(bullet);
        GameObject tmp = Instantiate(bullet, bulletSpot.position, Quaternion.LookRotation(dir));
        tmp.GetComponent<BulletBehavior>().SetSpeed(projectileSpeed);
        canFire = false;
        fireRateTimer = 0;
    }
}
