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
    public bool currencyReset;
   
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
        currency = currency - 60;
        buttonPressed = true;
    }

    public void Update()
    {
        if(currency != oldCurrency)
        {
            oldCurrency = currency;
        }

        if(currencyReset == true)
        {
            currency = 0;
            oldCurrency = 0;
            currencyReset = false;
        }

        else
        {
            buttonPressed = false;
        }

        if(buttonPressed == false)
        {
            currency = 0;
            oldCurrency = 0;
        }
       
    }
}
