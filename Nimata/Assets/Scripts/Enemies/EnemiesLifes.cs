using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesLifes : MonoBehaviour
{
    [SerializeField] int lifeCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetHit()
    {
        lifeCount --;
        if (lifeCount == 0)
        {
            Destroy(transform.gameObject);
        }
    }
}
