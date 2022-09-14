using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    
    public float[] counter;
    private bool wave2bool;
    private bool wave2check;

    void Start()
    {
        //public GameObject[] myObjects = GameObject.Find("Spawnpoint").GetComponent<Spawning>().myObjects;
    }

    void Update()
    {
        wave2bool = GameObject.Find("Spawnpoint").GetComponent<Spawning>().wave2bool;
        if(wave2check == false)
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
