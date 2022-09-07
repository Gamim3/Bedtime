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
    public float waveCounter;
    public List<GameObject> myObjects;
    public bool spawn0;
    public bool spawn1;
    public bool spawn2;
    public bool spawn3;

    void Update()
    {
        enemy1 = GameObject.Find("Bullets").GetComponent<Bullet>().float1;
        enemy2 = GameObject.Find("Bullets").GetComponent<Bullet>().float2;
        enemy3 = GameObject.Find("Bullets").GetComponent<Bullet>().float3;
        enemy4 = GameObject.Find("Bullets").GetComponent<Bullet>().float4;


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

        for(int i = 10; i > 0; i--)
        {

        }

        if (enemy1 < 1)
        {
            spawn0 = false;
            waveCounter += 1;
        }
        
        if (enemy2 < 1)
        {
            spawn1 = false;
            waveCounter += 1;
        }
        
        if (enemy3 < 1)
        {
            spawn2 = false;
            waveCounter += 1;
        }

        if (enemy4 < 1)
        {
            spawn3 = false;
            //myObjects.Remove(ScriptableObject.CreateInstance("Enemy 1") as GameObject);
            waveCounter += 1;
        }

        if(waveCounter == 4)
        {
            //wave2 will begin.
        }
        
        
    }
}
