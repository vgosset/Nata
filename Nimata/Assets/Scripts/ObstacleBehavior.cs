using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    [SerializeField] int lifeCount;
    [SerializeField] List<Material> matType = new List<Material>();
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = matType[lifeCount - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) 
    {

        if (other.transform.tag == "Bullets")
        {
            lifeCount --;
            if (lifeCount == 0)
                Destroy(transform.gameObject);
            else
                GetComponent<Renderer>().material = matType[lifeCount - 1];
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "EnemyBullets")
        {
            Destroy(other.gameObject);
        }
    }
}
