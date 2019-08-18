using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneniesBulletBehavior : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {

    }

    void Update()
    {

    }
    public void SetSpeed(float speed)
    {
        rb.velocity  = transform.rotation * Vector3.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "BoundariesBullets")
          Destroy(transform.gameObject);
        
        if (other.transform.tag == "Enemies")
        {
            Destroy(transform.gameObject);
        }
    }
}
