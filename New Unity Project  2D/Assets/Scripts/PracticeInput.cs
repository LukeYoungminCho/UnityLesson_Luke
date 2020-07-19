using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input.GetKey(KeyCode.M); // 키 누르는 동안 true 리턴
        Input.GetKeyDown(KeyCode.M); // 키 눌러지는 순간 한번 true 리턴
        Input.GetKeyUp(KeyCode.M); // 키 눌렀다 떨어지는 순간 한번 true 리턴

        if ((Input.GetKeyDown(KeyCode.W) == true) & (Input.GetKeyDown(KeyCode.LeftShift) == true))
        {
            Debug.Log("Shift + W 키가 입력되었습니다.");
        }
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Debug.Log("E 키가 입력되었습니다.");
        }
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            Debug.Log("R 키가 입력되었습니다.");
        }
    }
}
