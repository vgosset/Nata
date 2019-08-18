using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IATargetBehavior : MonoBehaviour
{

    [SerializeField] private float projectileSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private Transform bulletSpot;

    private bool canFire = true;
    private GameObject target;
    float fireRateTimer;

    void Start()
    {
       target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (canFire)
            fire();
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer > fireRate)
            canFire = true;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position,  movementSpeed * Time.deltaTime);

        Vector3 targetDir = target.transform.position - transform.position;

        float step = rotateSpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void fire()
    {
        canFire = false;
        fireRateTimer = 0;
        GameObject tmp = Instantiate(bullet, bulletSpot.position, Quaternion.LookRotation(bulletSpot.rotation * Vector3.forward));
        tmp.GetComponent<EneniesBulletBehavior>().SetSpeed(projectileSpeed);
    }
}
