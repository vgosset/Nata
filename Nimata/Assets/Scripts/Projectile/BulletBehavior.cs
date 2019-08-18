using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSpeed(float speed)
    {
        rb.velocity  = transform.rotation * Vector3.forward * speed;
    }

    private void OnColliderEnter(Collision other)
    {

    }
    private void OnTriggerEnter(Collider other)
    {
      if (other.transform.tag == "BoundariesBullets")
          Destroy(transform.gameObject);
      if (other.transform.tag == "EnemyBullets")
      {
          Destroy(other.transform.gameObject);
          Destroy(transform.gameObject);
      }
      if (other.transform.tag == "Enemies")
      {
          other.transform.GetComponent<EnemiesLifes>().GetHit();
          Destroy(transform.gameObject);
      }
    }
}
