using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVLscreen : MonoBehaviour
{
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

    //to infoscreen
    public void LvlSelect()
    {
        SceneManager.LoadScene("infoscreen");
    }

    //to toturial
    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

}
