using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSpriralEnemy : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] float projectileSpeed;
    private float fireRateTimer;
    [SerializeField] private GameObject bullet;
    private bool canFire = true;
    [SerializeField] List<Transform> bulletSpot = new List<Transform>();
    [SerializeField] int spotCount;

    void Start()
    {
        
    }

    void Update()
    {
        if (canFire) 
            fire();
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer > fireRate)
            canFire = true;
    }
    public void FixedUpdate() 
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 200);
    }

    private void fire()
    {
        for (int i = 0; i < spotCount; i++)
        {
            GameObject tmp = Instantiate(bullet, bulletSpot[i].position, Quaternion.LookRotation(bulletSpot[i].rotation * Vector3.forward));
            tmp.GetComponent<BulletBehavior>().SetSpeed(projectileSpeed);
        }
        canFire = false;
        fireRateTimer = 0;
    }
}
