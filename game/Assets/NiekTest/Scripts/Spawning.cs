using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawning : MonoBehaviour
{
    public float spawnTime;
    public float wave;
    public Text waveCounter;
    public List<GameObject> myObjects;

    public bool[] spawn;
    public bool wave2check;
    public float[] counter;
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

        int randomIndex = Random.Range(0, 4);
        spawnTime += Time.deltaTime;
        if(spawnTime > 1)
        {
            if (randomIndex == 0 && counter[0] > 0)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[0], transform.position, Quaternion.identity) as GameObject;
                counter[0] -= 1;
            }

            if (randomIndex == 1 && counter[1] > 0)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[1], transform.position, Quaternion.identity) as GameObject;
                counter[1] -= 1;
            }

            if (randomIndex == 2 && counter[2] > 0)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[2], transform.position, Quaternion.identity) as GameObject;
                counter[2] -= 1;
            }

            if (randomIndex == 3 && counter[3] > 0)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[3], transform.position, Quaternion.identity) as GameObject;
                counter[3] -= 1;
            }    
        }

        //for(int i = 20; i > enemy1; i--)
        //{  
        //}
       
        if(wave2check == true)
        {
            wave += 1;
            waveCounter.text = wave.ToString();
        }
    }
}
