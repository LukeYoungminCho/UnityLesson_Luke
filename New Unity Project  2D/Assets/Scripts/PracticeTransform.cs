using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PracticeTransform : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {            
            transform.position = transform.position + new Vector3(0, 0.02f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + new Vector3(0, -0.02f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-0.02f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(0.02f, 0, 0);
        }
        // transform.position = transform.position + Vector3.up * 0.02f; 동일함.  Vector3.up 은 위방향 단위벡터 ( 0,1,0)

    }
}
