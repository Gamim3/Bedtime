using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float[] counter;
    public float currency;
    public Text currencyUI;

    public bool wave2check;
    private bool buttonPressed;
    public float[] enemyAmount;
    public float waveMultiplier;


    public Text[] enemyText;

    void Start()
    {
        //public GameObject[] myObjects = GameObject.Find("Spawnpoint").GetComponent<Spawning>().myObjects;
        enemyAmount[0] = counter[0];
        enemyAmount[1] = counter[1];
        enemyAmount[2] = counter[2];
        enemyAmount[3] = counter[3];
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy 1")
        {
            EnemyStats stats1 = other.gameObject.GetComponent<Enemy>().stats;
            counter[0] -= 1;
            
            Destroy(other.gameObject);
            currency += stats1.value;
        }

        if(other.gameObject.tag == "enemy 2")
        {
            EnemyStats stats2 = other.gameObject.GetComponent<Enemy>().stats;
            counter[1] -= 1;
            Destroy(other.gameObject);
            currency += stats2.value;
        }

        if(other.gameObject.tag == "enemy 3")
        {

            counter[2] -= 1;
            EnemyStats stats3 = other.gameObject.GetComponent<Enemy>().stats;
            Destroy(other.gameObject);
            currency += stats3.value;
        }

        if(other.gameObject.tag == "enemy 4")
        {
            EnemyStats stats4 = other.gameObject.GetComponent<Enemy>().stats;
            counter[3] -= 1;  
            Destroy(other.gameObject);
            currency += stats4.value;
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
