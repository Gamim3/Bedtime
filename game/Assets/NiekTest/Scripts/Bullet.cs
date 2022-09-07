using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private Text enemy1textUI;
    private Text enemy2textUI;
    private Text enemy3textUI;
    private Text enemy4textUI;
    public float float1;
    public float float2;
    public float float3;
    public float float4;

    void Start()
    {
        //public GameObject[] myObjects = GameObject.Find("Spawnpoint").GetComponent<Spawning>().myObjects;

        enemy1textUI = GameObject.Find("Enemy1").GetComponent<Text>();
        enemy2textUI = GameObject.Find("Enemy2").GetComponent<Text>();
        enemy3textUI = GameObject.Find("Enemy3").GetComponent<Text>();
        enemy4textUI = GameObject.Find("Enemy4").GetComponent<Text>();
    }
    void OnCollisionEnter(Collision other)
    {
            if(other.gameObject.tag == "enemy 1")
            {
                float1 -= 1;
                Destroy(other.gameObject);
            }

            if(other.gameObject.tag == "enemy 2")
            {
                float2 -= 1;
                Destroy(other.gameObject);
            }

            if(other.gameObject.tag == "enemy 3")
            {
                float3 -= 1;
                Destroy(other.gameObject);
            }

            if(other.gameObject.tag == "enemy 4")
            {
                float4 -= 1;  
                Destroy(other.gameObject);
            }
    }

    void Update()
    {
        enemy1textUI.text = float1.ToString();
        enemy2textUI.text = float2.ToString();
        enemy3textUI.text = float3.ToString();
        enemy4textUI.text = float4.ToString();
    }
    
}
