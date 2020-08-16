using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIBlink : MonoBehaviour
{
    public float intervalSec = 1f;
    Text[] texts;
    Image[] images;

    void Start()
    {
        //List<Text> texts = this.gameObject.GetComponents<Text>().ToList<Text>();
        texts = this.gameObject.GetComponentsInChildren<Text>();

        //List<Image> images = this.gameObject.GetComponents<Image>().ToList<Image>();
        images = this.gameObject.GetComponentsInChildren<Image>();

        StartCoroutine(Blink());
       
    }

    IEnumerator Blink()
    {   
        bool isInverse = false;
        float currentAlpha = 0f;

        while (this.gameObject.activeSelf == true)
        {
            
            float offset = 1f / intervalSec * Time.deltaTime;
            
            if (currentAlpha >= 1f)
            {
                Debug.Log("hide");
                isInverse = true;
                currentAlpha = 1f;
            }
            else if (currentAlpha <= 0f)
            {
                Debug.Log("show");
                isInverse = false;
                currentAlpha = 0f;
            }

            if(isInverse == true)
            {
                currentAlpha -= offset;
            }
            else if(isInverse ==false)
            {
                currentAlpha += offset;
            }

            if (texts != null)
            {
                Debug.Log("Text is not null");
                foreach (Text text in texts)
                {
                    Debug.Log("text blinking");
                    text.color = new Color(text.color.r, text.color.g, text.color.b, currentAlpha);
                }
            }
            if (images != null)
            {
                Debug.Log("Text is not null");
                foreach (Image image in images)
                {
                    Debug.Log("image blinking");
                    image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
                }
            }
            yield return null;
        }

    }
}
