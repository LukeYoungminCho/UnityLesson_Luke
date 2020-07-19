using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeScale : MonoBehaviour
{
    int ScaleFlag = -1;

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 1f)
        {
            ScaleFlag = 1;
        }
        else if (transform.localScale.x > 5f)
        {
            ScaleFlag = -1;
        }

        if (ScaleFlag == 1)
        {
            transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0);
        }
        else if (ScaleFlag == -1)
        {
            transform.localScale = transform.localScale - new Vector3(0.1f, 0.1f, 0);
        }
        
    }
}
