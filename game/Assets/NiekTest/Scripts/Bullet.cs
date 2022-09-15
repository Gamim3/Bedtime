using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float[] counter;
    public float currency;
    public Text currencyUI;
    public List<float> enemyValue;

    private bool wave2check;
    private bool wave2bool;
    private bool buttonPressed;

    public Text[] enemyText;

    void Start()
    {
        //public GameObject[] myObjects = GameObject.Find("Spawnpoint").GetComponent<Spawning>().myObjects;

    }
    void OnCollisionEnter(Collision other)
    {
            if(other.gameObject.tag == "enemy 1")
            {
                counter[0] -= 1;
                Destroy(other.gameObject);
                currency = currency + enemyValue[0];
            }

            if(other.gameObject.tag == "enemy 2")
            {
                counter[1] -= 1;
                Destroy(other.gameObject);
                currency = currency + enemyValue[1];
            }

            if(other.gameObject.tag == "enemy 3")
            {
                counter[2] -= 1;
                Destroy(other.gameObject);
                currency = currency + enemyValue[2];
            }

            if(other.gameObject.tag == "enemy 4")
            {
                counter[3] -= 1;  
                Destroy(other.gameObject);
                currency = currency + enemyValue[3];
            }
    }

    void Update()
    {
        //currency = currency - GameObject.Find("ShopButton").GetComponent<Shop>().currency;

        enemyText[0].text = counter[0].ToString();
        enemyText[1].text = counter[1].ToString();
        enemyText[2].text = counter[2].ToString();
        enemyText[3].text = counter[3].ToString();
        currencyUI.text = currency.ToString();
        wave2bool = GameObject.Find("Spawnpoint").GetComponent<Spawning>().wave2bool;
        if (wave2check == false)
        {
            if (wave2bool == true)
            {
                counter[0] = 20;
                counter[1] = 16;
                counter[2] = 12;
                counter[3] = 8;
                wave2check = true;
            }
        }
        //currency = currency + GameObject.Find("ShopItem1").GetComponent<Shop>().currency; //werkt alleen als shop open is
        buttonPressed = Object.FindObjectOfType<Shop>().GetComponent<Shop>().buttonPressed;
        if(buttonPressed == true)
        {
            currency = currency + Object.FindObjectOfType<Shop>().GetComponent<Shop>().currency;
            buttonPressed = false;
        }
    }
}
