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

        enemyText[0].text = counter[0].ToString();
        enemyText[1].text = counter[1].ToString();
        enemyText[2].text = counter[2].ToString();
        enemyText[3].text = counter[3].ToString();
        currencyUI.text = currency.ToString();
        wave2check = GameObject.Find("Spawnpoint").GetComponent<Spawning>().wave2check;
        
        if (counter[0] < 1 && counter[1] < 1 && counter[2] < 1 && counter [3] < 1)
        {
            waveMultiplier += 1;
            counter[0] = enemyAmount[0] * waveMultiplier;
            counter[1] = enemyAmount[1] * waveMultiplier;
            counter[2] = enemyAmount[2] * waveMultiplier;
            counter[3] = enemyAmount[3] * waveMultiplier;
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
