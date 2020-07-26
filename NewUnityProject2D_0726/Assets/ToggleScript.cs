using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public Toggle targetToggle;
    public Text targetText;
    public void OnClickToggle()
    {
        targetText.text = targetToggle.isOn ? "토글 On" : "토글 Off";
    }
}
