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
    public GameObject[] towers;
    private bool towerAbleToPlace;
    public GameObject tower;
    
    public TMP_Text towerText;

    public void BuyItem(int buttonint)
    {
        if(shopCurrency > towers[buttonint].GetComponent<TowerBase>().towerData.cost - 1)
        {
            currency = -towers[buttonint].GetComponent<TowerBase>().towerData.cost;
            tower = towers[buttonint];
            buttonPressed = true;
        }
    }

    public void Update()
    {
        towerAbleToPlace = GameObject.Find("GameObject").GetComponent<NewBuildSystem>().towerAbleToPlace;
        if(towerAbleToPlace)
        {
            towerText.text = ("hasTower");
        }

        else
        {
            towerText.text = ("noTower");
            tower = null;
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
