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
            GameObject instantiatedObject = Instantiate(myObjects[randomIndex], transform.position, Quaternion.identity) as GameObject;
            spawnTime = 0;
        }

        

        if (enemy1 < 1)
        {
            myObjects.Remove(myObjects[0]);
            waveCounter += 1;
        }
        
        if (enemy2 < 1)
        {
            myObjects.Remove(myObjects[1]);
            waveCounter += 1;
        }
        
        if (enemy3 < 1)
        {
            myObjects.Remove(myObjects[2]);
            waveCounter += 1;
        }

        if (enemy4 < 1)
        {
            myObjects.Remove(myObjects[3]);
            //myObjects.Remove(ScriptableObject.CreateInstance("Enemy 1") as GameObject);
            waveCounter += 1;
        }

        if(waveCounter == 4)
        {
            //wave2 will begin.
        }
        
        
    }
}
