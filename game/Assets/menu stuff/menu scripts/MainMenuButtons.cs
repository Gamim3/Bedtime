using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenubuttons : MonoBehaviour
{
    //this will exit the game
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("game closed");
    }

    //this will go to the lvl scene
}
