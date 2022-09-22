using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawning : MonoBehaviour
{
    public float spawnTime;
    public float[] enemy;

    public float wave2;

    public Text waveCounter;
    public List<GameObject> myObjects;

    public bool[] spawn;
    public bool wave2check;
    void Update()
    {
        enemy[0] = GameObject.Find("EnemyCounter").GetComponent<EnemyCounter>().counter[0];
        enemy[1] = GameObject.Find("EnemyCounter").GetComponent<EnemyCounter>().counter[1];
        enemy[2] = GameObject.Find("EnemyCounter").GetComponent<EnemyCounter>().counter[2];
        enemy[3] = GameObject.Find("EnemyCounter").GetComponent<EnemyCounter>().counter[3];

        wave2check = GameObject.Find("Bullets").GetComponent<Bullet>().wave2check;


        int randomIndex = Random.Range(0, 4);
        spawnTime += Time.deltaTime;
        if(spawnTime > 1)
        {
            if (randomIndex == 0 && spawn[0] == true)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[0], transform.position, Quaternion.identity) as GameObject;
            }

            if (randomIndex == 1 && spawn[1] == true)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[1], transform.position, Quaternion.identity) as GameObject;
            }

            if (randomIndex == 2 && spawn[2] == true)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[2], transform.position, Quaternion.identity) as GameObject;
            }

            if (randomIndex == 3 && spawn[3] == true)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[3], transform.position, Quaternion.identity) as GameObject;
            }    
        }

        //for(int i = 20; i > enemy1; i--)
        //{  
        //}

        if (enemy[0] < 1)
        {
            spawn[0] = false;
        }

        else
        {
            spawn[0] = true;
        }
        
        if (enemy[1] < 1)
        {
            spawn[1] = false;
        }

        else
        {
            spawn[1] = true;
        }

        if (enemy[2] < 1)
        {
            spawn[2] = false;
        }

        else
        {
            spawn[2] = true;
        }

        if (enemy[3] < 1)
        {
            spawn[3] = false;
            //myObjects.Remove(ScriptableObject.CreateInstance("Enemy 1") as GameObject);
        }

        else
        {
            spawn[3] = true;
        }

        if (enemy[3] < 1 && enemy[2] < 1 && enemy[1] < 1 && enemy[0] < 1)
        {
            if(wave2 == 1)
            {
                //waveCounter.text = 3.ToString();
            }
        }
       
        if(wave2check == true)
        {
            wave2 += 1;
            waveCounter.text = wave2.ToString();
            
        }
        
    }
}
