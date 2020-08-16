using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    
    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
