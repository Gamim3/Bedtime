using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Shop : MonoBehaviour
{
    public float currency;
    public GameObject shopUI;
    public bool inMenu;
    public GameObject[] towers;
    public float[] counter;
    private bool inShopBase;
    private bool inShopBaseCheck;

    public TMP_Text towerText;
    public TMP_Text currencyUI;

    public GameObject buildingsystem;
    public GameObject tower;

    public GameObject toolMenu;
    public GameObject spawningScript;
    public GameObject shopScript;
    public GameObject shopBaseUI;
    public GameObject inputs;
    public GameObject phoney;
    public GameObject camsObject;

    public GameObject coldwheels;
    public GameObject clonecoldWheels;
    public Transform coldspawnpoint;

    public int bulletAmount;
    public void BuyPhony()
    {
        phoney.GetComponent<Phoney>().Spawner(true);
    }
    public void BuyColdWHeels()
    {
        if (clonecoldWheels == null)
        {
            clonecoldWheels = Instantiate(coldwheels, coldspawnpoint);
        }
        else
        {
            clonecoldWheels.GetComponent<HotwheelsTower>().Spawner(bulletAmount);
        }
    }
    public void BuyItem(int buttonint)
    {
        if(currency > towers[buttonint].GetComponent<TowerBase>().towerData.cost - 1 && buildingsystem.GetComponent<NewBuildSystem>().tower == null)
        {
            
            currency -= towers[buttonint].GetComponent<TowerBase>().towerData.cost;
            buildingsystem.GetComponent<NewBuildSystem>().tower = towers[buttonint];
        }
    }

    public void ExitButton()
    {
        shopUI.SetActive(false);
        inMenu = false;
        toolMenu.SetActive(false);
    }

    public void Update()
    {
        currencyUI.text = currency.ToString();

        //towerAbleToPlace = GameObject.Find("GameObject").GetComponent<NewBuildSystem>().towerAbleToPlace;

        //if (towerAbleToPlace)
        //{
        //    towerText.text = ("hasTower");
        //}

        //else
        //{
        //    towerText.text = ("noTower");
        //    tower = null;
        //}

   
        if(camsObject.activeSelf == true)
        {
            camsObject.GetComponent<Cams>().inMenu = inMenu;
        }
            
        if (Input.GetKeyDown(KeyCode.T))
        {
            toolMenu.SetActive(true);
            inMenu = true;
        }

        inShopBase = GameObject.Find("BaseDoor").GetComponent<ShopBase>().inShopBase;
        if(inShopBase)
        {
            shopBaseUI.SetActive(true);
            inMenu = true;
            inShopBaseCheck = false;
        }

        if(inShopBase == false && inShopBaseCheck == false)
        {
            shopBaseUI.SetActive(false);
            inMenu = false;
            inShopBaseCheck = true;
        }
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

    public void SkipWave()
    {
        if(spawningScript.GetComponent<Spawning>().wave < 5)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject enemy in enemies)
            {
                GameObject.Destroy(enemy);
            }

            spawningScript.GetComponent<Spawning>().counter = counter;
            for (int i = 0; i < counter.Length; i++)
            {
                counter[i] = 0;
            }
        }

    }

    public void GetMoney()
    {
        currency += 100;
    }
}
