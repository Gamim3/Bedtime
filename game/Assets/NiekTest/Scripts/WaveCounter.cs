using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaveCounter : MonoBehaviour
{
    
    public float[] counter;
    public float currency;
    public TMP_Text currencyUI;

    public bool wave2check;
    private bool buttonPressed;
    public float[] enemyAmount;
    public float waveMultiplier;
    public TMP_Text[] enemyText;

    void Start()
    {
        //public GameObject[] myObjects = GameObject.Find("Spawnpoint").GetComponent<Spawning>().myObjects;
    }

    void Update()
    {
        //currency = currency - GameObject.Find("ShopButton").GetComponent<Shop>().currency;
        for (int i = 0; i < counter.Length; i++)
        {
            enemyText[i].text = counter[i].ToString();
        }
        currencyUI.text = currency.ToString();
        wave2check = GameObject.Find("Spawnpoint").GetComponent<Spawning>().wave2check;
        
        if (counter[0] < 1 && counter[1] < 1 && counter[2] < 1 && counter [3] < 1)
        {
            waveMultiplier += 1;
            for (int i = 0; i < counter.Length; i++)
            {
                counter[i] = enemyAmount[i] * waveMultiplier;
            }
            wave2check = true;
        }

        else
        {
            wave2check = false;
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
