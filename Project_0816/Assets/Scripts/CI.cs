using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CI : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.gameObject.SetActive(false);
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            slider.gameObject.SetActive(true);
            StartCoroutine(StartGame());
        }
        
    }

    IEnumerator StartGame()
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(1);
        while (oper.isDone == false)
        {
            slider.value = oper.progress;
            yield return null;
        }

        slider.value = 1;
    }

    
}
