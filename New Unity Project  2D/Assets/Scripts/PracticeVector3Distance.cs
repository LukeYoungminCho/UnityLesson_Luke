using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeVector3Distance : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target1.transform.position, target2.transform.position);        
        Debug.Log(distance);
    }
}
