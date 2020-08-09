using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleTon<GameManager>
{
    public int score;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); // 다른 Scene 으로 넘어가도 오브젝트를 유지함
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
