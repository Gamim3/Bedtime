using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathscreen : MonoBehaviour
{
    //back to lvl select
    public void LvlSelectScreen()
    {
        SceneManager.LoadScene("lvl select");
    }

    //restart game
    public void Level()
    {
        SceneManager.LoadScene("KamerScene");
    }

    //restart game for tutorial
    public void tutorial2()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
