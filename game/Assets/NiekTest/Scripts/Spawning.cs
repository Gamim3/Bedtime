using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawning : MonoBehaviour
{
    public float spawnTime;
    public float enemy1;
    public float enemy2;
    public float enemy3;
    public float enemy4;

    public float wave2;
    public float wave2Time;

    public Text waveCounter;
    public List<GameObject> myObjects;

    public bool spawn0;
    public bool spawn1;
    public bool spawn2;
    public bool spawn3;
    public bool wave2bool;

    void Update()
    {
        enemy1 = GameObject.Find("EnemyCounter").GetComponent<EnemyCounter>().float1;
        enemy2 = GameObject.Find("EnemyCounter").GetComponent<EnemyCounter>().float2;
        enemy3 = GameObject.Find("EnemyCounter").GetComponent<EnemyCounter>().float3;
        enemy4 = GameObject.Find("EnemyCounter").GetComponent<EnemyCounter>().float4;


        int randomIndex = Random.Range(0, 4);
        spawnTime += Time.deltaTime;
        if(spawnTime > 1)
        {
            if (randomIndex == 0 && spawn0 == true)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[0], transform.position, Quaternion.identity) as GameObject;
            }

            if (randomIndex == 1 && spawn1 == true)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[1], transform.position, Quaternion.identity) as GameObject;
            }

            if (randomIndex == 2 && spawn2 == true)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[2], transform.position, Quaternion.identity) as GameObject;
            }

            if (randomIndex == 3 && spawn3 == true)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[3], transform.position, Quaternion.identity) as GameObject;
            }    
        }

        //for(int i = 20; i > enemy1; i--)
        //{  
        //}

        if (enemy1 < 1)
        {
            spawn0 = false;
        }

        else
        {
            spawn0 = true;
        }
        
        if (enemy2 < 1)
        {
            spawn1 = false;
        }

        else
        {
            spawn1 = true;
        }

        if (enemy3 < 1)
        {
            spawn2 = false;
        }

        else
        {
            spawn2 = true;
        }

        if (enemy4 < 1)
        {
            spawn3 = false;
            //myObjects.Remove(ScriptableObject.CreateInstance("Enemy 1") as GameObject);
        }

        else
        {
            spawn3 = true;
        }

        if (enemy4 < 1 && enemy3 < 1 && enemy2 < 1 && enemy1 < 1)
        {
            waveCounter.text = 2.ToString();
            wave2Time += Time.deltaTime;
            
            if(wave2 == 1)
            {
                //waveCounter.text = 100.ToString();
            }
        }

        if(wave2bool == false)
        {
            if (wave2Time > 14)
            {
                wave2 += 1;
                wave2bool = true;
            }
        }
    }
}
