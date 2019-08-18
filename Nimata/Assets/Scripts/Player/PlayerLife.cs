using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] bool cheat;
    [SerializeField] int lifeCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayerGetHit()
    {
      if(!cheat)
      {
        lifeCount --;
        if (lifeCount == 0)
        {
          Time.timeScale = 0f;
          // Destroy(transform.gameObject);
        }
      }
    }

}
