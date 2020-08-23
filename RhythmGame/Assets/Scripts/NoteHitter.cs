using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteHitter : MonoBehaviour
{
    public Image targetImage;
    public KeyCode targetKeyCode;
    [HideInInspector]
    public bool canHit = true;

    private void Awake()
    {
        this.gameObject.name = $"NoteHitter - {targetKeyCode}";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(targetKeyCode))
        {
            targetImage.color = Color.yellow;
        }
        else
        {
            targetImage.color = Color.white;
            canHit = true;
        }
    }
}
