using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image circleTable;

    public float circleTableRotateSpeed = 0.05f;
    private Vector3 rotateVector;

    private void Start()
    {
        rotateVector = new Vector3(0, 0, 0.0005f);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void PlayEditor()
    {
        SceneManager.LoadScene("Editor");
    }

    private void Update()
    {
        circleTable.transform.Rotate(rotateVector, circleTableRotateSpeed);   
    }
}
