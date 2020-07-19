using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Practice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("일반 로그");
        Debug.LogWarning("경고 로그");
        Debug.LogError("에러 로그");

        Debug.LogFormat("해당 값은 뭐지 ? : {0}", 12345);
        Debug.LogWarningFormat("해당 값은 뭐지 ? : {0}", 12345);
        Debug.LogErrorFormat("해당 값은 뭐지 ? : {0}", 12345);

        Debug.Log($"해당 값은 뭐지 ? : {12345}");
        Debug.LogWarning($"해당 값은 뭐지 ? : {12345}");
        Debug.LogError($"해당 값은 뭐지 ? : {12345}");

        Debug.Log(string.Format("해당 값은 뭐지 ? : {0}",12345));
        Debug.LogWarning(string.Format("해당 값은 뭐지 ? : {0}", 12345));
        Debug.LogError(string.Format("해당 값은 뭐지 ? : {0}", 12345));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
