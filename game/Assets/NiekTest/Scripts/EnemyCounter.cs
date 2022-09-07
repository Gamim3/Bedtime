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
    // vieze code ;( 
    void Start()
    {
        //public GameObject[] myObjects = GameObject.Find("Spawnpoint").GetComponent<Spawning>().myObjects;

        
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
    void Update()
    {
        
    }
}
