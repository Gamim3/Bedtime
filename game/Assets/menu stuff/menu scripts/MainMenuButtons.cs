using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    //this will exit the game
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("game closed");
    }

    //this will go to the lvl scene

    public void StartGame()
    {
        SceneManager.LoadScene("KamerScene");
    }
}
