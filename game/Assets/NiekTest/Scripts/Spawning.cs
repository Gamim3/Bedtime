using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawning : MonoBehaviour
{
    public GameObject playerinputs;
    public GameObject inMenuScript;
    //gameobjects
    public List<GameObject> myObjects;
    public GameObject Waypoints;
    public GameObject finish;
    public GameObject gameUI;
    //bools
    public bool[] spawn;
    public bool endGame;
    private bool spawning;
    
    //floats
    public float[] counter;
    
    public float[] spawnCounter;
    public float spawnTime;
    public float wave;

    public float[] wave1counter;
    public float[] wave2counter;
    public float[] wave3counter;
    public float[] wave4counter;
    public float[] wave5counter;

    //text
    public TMP_Text[] enemyText;
    public TMP_Text waveCounter;
    
    void Start()
    {
        
    }

    void Update()
    {

        if(playerinputs.GetComponent<PlayerInputs>().startwaveInput)
        {
            spawning = true;
        }

        int randomIndex = Random.Range(0, 4);
        spawnTime += Time.deltaTime;
        if(spawnTime > 1 && spawning)
        {
            
            if (randomIndex == 0 && spawnCounter[0] > 0)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[0], transform.position, transform.rotation) as GameObject;
                instantiatedObject.GetComponent<Enemy>().Wpoints = Waypoints.GetComponent<Waypoints>();
                spawnCounter[0] -= 1;
            }

            if (randomIndex == 1 && spawnCounter[1] > 0)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[1], transform.position, transform.rotation) as GameObject;
                instantiatedObject.GetComponent<Enemy>().Wpoints = Waypoints.GetComponent<Waypoints>();
                spawnCounter[1] -= 1;
            }

            if (randomIndex == 2 && spawnCounter[2] > 0)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[2], transform.position, transform.rotation) as GameObject;
                instantiatedObject.GetComponent<Enemy>().Wpoints = Waypoints.GetComponent<Waypoints>();
                spawnCounter[2] -= 1;
            }

            if (randomIndex == 3 && spawnCounter[3] > 0)
            {
                spawnTime = 0;
                GameObject instantiatedObject = Instantiate(myObjects[3], transform.position, transform.rotation) as GameObject;
                instantiatedObject.GetComponent<Enemy>().Wpoints = Waypoints.GetComponent<Waypoints>();
                spawnCounter[3] -= 1;
            }    
        }

        for (int i = 0; i < counter.Length; i++)
        {
            enemyText[i].text = counter[i].ToString();
        }


        if (counter[0] < 1 && counter[1] < 1 && counter[2] < 1 && counter[3] < 1 && wave < 5)
        {
            wave++;
            waveCounter.text = wave.ToString();
            spawning = false;
            for (int i = 0; i < counter.Length; i++)
            {
                if (wave == 2)
                {
                    counter[i] = wave2counter[i];
                    spawnCounter[i] = wave2counter[i];
                }

                if (wave == 3)
                {
                    counter[i] = wave3counter[i];
                    spawnCounter[i] = wave3counter[i];
                }

                if (wave == 4)
                {
                    counter[i] = wave4counter[i];
                    spawnCounter[i] = wave4counter[i];
                }

                if (wave == 5)
                {
                    counter[i] = wave5counter[i];
                    spawnCounter[i] = wave5counter[i];
                    endGame = true;
                }
            }
 
        }

        if (counter[0] < 1 && counter[1] < 1 && counter[2] < 1 && counter[3] < 1 && endGame)
        {
            finish.SetActive(true);
            gameUI.SetActive(false);
            inMenuScript.GetComponent<Cams>().inMenu = true;
        }
    }
}
