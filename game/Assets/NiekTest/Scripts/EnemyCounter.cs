using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    
    public float[] counter;
    private bool wave2bool;
    private bool wave2check;
    private float[] enemyAmount;
    private float waveMultiplier;
    void Update()
    {

        wave2check = GameObject.Find("Bullets").GetComponent<Bullet>().wave2check;
        
            if (wave2check == true)
            {
                enemyAmount = GameObject.Find("Bullets").GetComponent<Bullet>().enemyAmount;
                waveMultiplier = GameObject.Find("Bullets").GetComponent<Bullet>().waveMultiplier;
                counter[0] = enemyAmount[0] * waveMultiplier;
                counter[1] = enemyAmount[1] * waveMultiplier;
                counter[2] = enemyAmount[2] * waveMultiplier;
                counter[3] = enemyAmount[3] * waveMultiplier;
            }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy 1")
        {
            counter[0] -= 1;
            
        }

        if (other.gameObject.tag == "enemy 2")
        {
            counter[1] -= 1;
            
        }

        if (other.gameObject.tag == "enemy 3")
        {
            counter[2] -= 1;
            
        }

        if (other.gameObject.tag == "enemy 4")
        {
            counter[3] -= 1;
            
        }
    }
}
