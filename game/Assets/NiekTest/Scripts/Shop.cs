using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public float currency;
    public Text currencyText;
   
    public void LoadMenu()
    {
        ShopManager.instance.ToggleShop();
    }

    public void LoadItem1()
    {
        currency = currency - 20;
    }

    public void LoadItem2()
    {
        currency = currency - 40;
    }

    public void LoadItem3()
    {
        currency = currency - 60;
    }
}
