using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    
    public float float1;
    public float float2;
    public float float3;
    public float float4;
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
                float1 = 20;
                float2 = 16;
                float3 = 12;
                float4 = 8;
                wave2check = true;
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy 1")
        {
            float1 -= 1;
            
        }

        if (other.gameObject.tag == "enemy 2")
        {
            float2 -= 1;
            
        }

        if (other.gameObject.tag == "enemy 3")
        {
            float3 -= 1;
            
        }

        if (other.gameObject.tag == "enemy 4")
        {
            float4 -= 1;
            
        }
    }
    
}
