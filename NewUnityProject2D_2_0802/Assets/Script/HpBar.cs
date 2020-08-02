using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Player playerScript;
    public Slider sliderScript;
    // Update is called once per frame
    void Update()
    {
        sliderScript.value = playerScript.hp;
    }
}
