using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeRotation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 1, transform.rotation.eulerAngles.z);
        transform.Rotate(new Vector3(0, 1, 0)); //위와 같은표현
    }
}
