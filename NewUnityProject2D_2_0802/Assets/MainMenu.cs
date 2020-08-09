using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButtonPressed()
    {
        Debug.Log("GameStart!");
        StartCoroutine(LoadScene());
        StageManager.Instance.StartStage(1);
    }

    IEnumerator LoadScene()
    {
        yield return SceneManager.LoadSceneAsync(1);

        // 씬 넘어갈때 로딩화면 업데이트하는 방법:
        /*
        AsyncOperation operation = ~~~
        while (operation.isDone)
        {
            operation.progress; // 0 ~ 1 . 로딩 진행 정도에따라 리턴
        yield return null;
        }
        */


        yield return null;
        StageManager.Instance.StartStage(1);
    }
}
