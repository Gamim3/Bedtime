using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauzeMenu : MonoBehaviour
{
    public GameObject escapeMenu;

    //resume game
    private void Update()
    {
        EscapeMenu();
    }

    public void EscapeMenu()
    {
        escapeMenu.SetActive(true);
    }

    //go to lvl selectscreen
    public void Lvlselect()
    {
        SceneManager.LoadScene("lvl select");
    }

}
