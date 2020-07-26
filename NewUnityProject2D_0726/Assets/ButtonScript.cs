using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Text targetText;
    private int clickCount;
    public void OnClickButton()
    {        
        targetText.text = $"{++clickCount} 회 만큼 눌려짐";
    }
}
