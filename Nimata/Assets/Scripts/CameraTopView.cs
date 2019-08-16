using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTopView : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z + offset.z); // Follow Player X axis 
    }
}
