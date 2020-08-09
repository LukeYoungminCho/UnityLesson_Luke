using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreUI : MonoBehaviour
{
    public Text uiText;
    private void FixedUpdate()
    {
        uiText.text = $"{GameManager.Instance.score}";
    }
}
