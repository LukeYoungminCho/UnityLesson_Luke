using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeSpriteColour : MonoBehaviour
{
    public GameObject target1;

    public SpriteRenderer targetRenderer;

    // Update is called once per frame
    void Start()
    {
        // 첫번째 방법
        SpriteRenderer renderer = target1.GetComponent<SpriteRenderer>();
        renderer.color = new Color(0, 0, 0, 0.5f); // r, g , b ,transparency
        //renderer.color = new Color32(255, 255, 255, 255);

        // 두번째 방법
        targetRenderer.color = new Color(0.5f, 0.5f, 0.5f, 1f);
    }
}
