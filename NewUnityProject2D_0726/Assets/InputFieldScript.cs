using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldScript : MonoBehaviour
{
    public InputField targetInputField;
    public Text targetText;

    private void Start()
    {
        targetText.text = "비밀번호를 입력하세요";
    }
    public void OnClickLoginButton()
    {
        if (targetInputField.text == "0000")
        {
            targetText.text = "로그인 성공";
            targetText.color = Color.blue;
        }
        else
        {
            targetText.text = "로그인 실패";
            targetText.color = Color.red;
        }
    }
}
