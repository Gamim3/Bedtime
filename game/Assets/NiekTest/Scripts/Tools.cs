using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tools : MonoBehaviour
{
    public GameObject toolMenu;
    public GameObject spawningScript;
    public GameObject shopScript;
    public float[] counter;
    private float currency;
    private bool inMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        GameObject.Find("Main Camera").GetComponent<Cams>().inMenu = inMenu;

        if (Input.GetKeyDown(KeyCode.T))
        {
            toolMenu.SetActive(true);
            inMenu = true;
        }


    }

    public void SkipWave()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }

        spawningScript.GetComponent<Spawning>().counter = counter;
        for (int i = 0; i < counter.Length; i++)
        {
            counter[i] = 0;
        }

    }

    public void GetMoney()
    {
        currency += 100;
        shopScript.GetComponent<Shop>().currency += currency;
        currency = 0;

    }

    public void Exit()
    {
        inMenu = false;
        toolMenu.SetActive(false);
    }
}
