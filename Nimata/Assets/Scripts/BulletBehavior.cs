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
        rb.velocity = transform.rotation * Vector3.forward * speed;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.transform.tag == "EnemyBullets" && transform.tag == "Bullets" || other.transform.tag == "Bullets" && transform.tag == "EnemyBullets" || other.transform.tag == "EnemyBullets" && transform.tag == "EnemyBullets")
        {
            Destroy(other.gameObject);
            Destroy(transform.gameObject);
        }
        if (other.transform.tag == "Player" && transform.tag == "EnemyBullets")
        {
            other.transform.GetComponent<PlayerLife>().PlayerGetHit();
            Destroy(transform.gameObject);
        }
        if (other.transform.tag == "Enemies")
        {
            if (transform.tag == "Bullets")
            {
                other.transform.GetComponent<EnemiesLifes>().GetHit();
                Destroy(transform.gameObject);
                
            }
            else if (transform.tag == "EnemyBullets")
                Destroy(transform.gameObject);
        }
    }
}
