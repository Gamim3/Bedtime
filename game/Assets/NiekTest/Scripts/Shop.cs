using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public float currency;
    public bool buttonPressed;
    public bool currencyReset;
    public float shopCurrency;
    public RaycastHit hit;
    public GameObject shopUI;
    public bool inMenu;
    public bool[] getTower;
    private bool towerAbleToPlace;

    public TMP_Text towerText;

    public void LoadItem1()
    {
        if (shopCurrency > 19)
        {
            currency = -20;
            buttonPressed = true;
            getTower[0] = true;
        }

    }
    public void LoadItem2()
    {
        if (shopCurrency > 39)
        {
            currency = -40;
            buttonPressed = true;
            getTower[1] = true;
        }
    }

    public void LoadItem3()
    {
        if (shopCurrency > 59)
        {
            currency = -60;
            buttonPressed = true;
            getTower[2] = true;

        }
    }

    public void Update()
    {
        
        towerAbleToPlace = GameObject.Find("GameObject").GetComponent<NewBuildSystem>().towerAbleToPlace;
        if(towerAbleToPlace)
        {
            towerText.text = ("hasTower");
            for (int i = 0; i < getTower.Length; i++)
            {
                getTower[i] = false;
            }
        }

        else
        {
            towerText.text = ("noTower");
        }

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

        shopCurrency = GameObject.Find("WaveCounterManager").GetComponent<WaveCounter>().currency;
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
