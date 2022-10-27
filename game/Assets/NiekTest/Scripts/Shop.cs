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
    public GameObject shopUI;
    public bool inMenu;
    public GameObject[] towers;
    private bool towerAbleToPlace;
    
    public TMP_Text towerText;
    public TMP_Text currencyUI;

    public GameObject buildingsystem;
    public GameObject tower;
    public GameObject spawn;

    public void BuyItem(int buttonint)
    {
        if(currency > towers[buttonint].GetComponent<TowerBase>().towerData.cost - 1 && buildingsystem.GetComponent<NewBuildSystem>().tower == null)
        {
            currency -= towers[buttonint].GetComponent<TowerBase>().towerData.cost;
            buildingsystem.GetComponent<NewBuildSystem>().tower = towers[buttonint];
            buttonPressed = true;
        }
    }

    public void ExitButton()
    {
        shopUI.SetActive(false);
        inMenu = false;
    }

    public void Update()
    {
        currencyUI.text = currency.ToString();
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
