using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public float currency;
    public Text currencyText;
    // Start is called before the first frame update
    void Start()
    {
        currencyText = GameObject.Find("CurrencyValue").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = currency.ToString();
    }

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
