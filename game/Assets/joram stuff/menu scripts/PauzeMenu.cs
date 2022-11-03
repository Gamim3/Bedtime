using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauzeMenu : MonoBehaviour
{
     //go to lvl selectscreen
    public void Lvlselect()
    {
        SceneManager.LoadScene("lvl select");
    }

}
