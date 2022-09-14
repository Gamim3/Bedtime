using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public float currency;
    public float oldCurrency;
    public bool buttonPressed;
   
    public void LoadMenu()
    {
        ShopManager.instance.ToggleShop();
    }

    public void LoadItem1()
    {
        currency = currency - 20;
        buttonPressed = true;
    }
    public void LoadItem2()
    {
        currency = currency - 40;
        buttonPressed = true;
    }

    public void LoadItem3()
    {
        buttonPressed = true;
        currency = currency - 60;
    }

    public void Update()
    {
        if(currency != oldCurrency)
        {
            oldCurrency = currency;
            buttonPressed = true;
        }

        else
        {
            buttonPressed = false;
        }
    }
}
