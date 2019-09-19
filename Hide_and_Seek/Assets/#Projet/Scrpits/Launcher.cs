using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void LaunchGame()
    {
        SceneManager.LoadScene("Game");

    }

    public void Quit()
    {
        Application.Quit();
    }
}
