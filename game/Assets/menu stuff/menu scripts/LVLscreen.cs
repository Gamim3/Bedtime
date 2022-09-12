using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVLscreen : MonoBehaviour
{
    // to settings menu
    public void Settings()
    {
        SceneManager.LoadScene("empty");
    }


    // to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("main menu");
    }


    // to gameplay
    public void StartGame()
    {
        SceneManager.LoadScene("KamerScene");
    }
}
