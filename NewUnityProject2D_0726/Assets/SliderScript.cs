using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider targetSlider;
    public Text targetText;

    private void Start()
    {
        OnValueChanged();
    }
    public void OnValueChanged()
    {
        targetText.text = $"{targetSlider.value}";
    }
}
