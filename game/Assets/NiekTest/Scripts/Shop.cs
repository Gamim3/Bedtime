using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public float currency;
    public bool buttonPressed;
    public bool currencyReset;
    public float bulletCurrency;
    public RaycastHit hit;
    public GameObject shopUI;
    public bool inMenu;

    public void LoadItem1()
    {
        if (bulletCurrency > 19)
        {
            currency = -20;
            buttonPressed = true;
        }

    }
    public void LoadItem2()
    {
        if (bulletCurrency > 39)
        {
            currency = -40;
            buttonPressed = true;
        }

    }

    public void LoadItem3()
    {
        if (bulletCurrency > 59)
        {
            currency = -60;
            buttonPressed = true;
        }
    }

    public void Update()
    {
        if (currencyReset == true)
        {
            currencyReset = false;
        }

        else
        {
            buttonPressed = false;
        }

        if (buttonPressed == false)
        {
            currency = 0;
        }

        bulletCurrency = GameObject.Find("WaveCounterManager").GetComponent<WaveCounter>().currency;
        GameObject.Find("Main Camera").GetComponent<Cams>().inMenu = inMenu;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            shopUI.SetActive(true);
            inMenu = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            shopUI.SetActive(false);
            inMenu = false;
        }
    }
}
