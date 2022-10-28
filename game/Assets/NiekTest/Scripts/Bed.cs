using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bed : MonoBehaviour
{
    public GameObject bedCam;
    public bool inBed;
    public GameObject ouders;

    public float time;
    public float waittime;

    public GameObject player;

    public GameObject build;

    public List<GameObject> towers = new List<GameObject>();

    private void Update()
    {
        if (inBed)
        {
            bedCam.SetActive(true);

            time += Time.deltaTime;

            player.SetActive(false);

            for (int i = 0; i < build.GetComponent<NewBuildSystem>().totalTowerIndex; i++)
            {
                if (towers != null)
                {
                    towers[i].GetComponent<TowerBase>().isInBed(false);
                }
            }

            if (time > waittime)
            {
                ouders.GetComponent<OuderSystem>().exposed = 0;
                bedCam.SetActive(false);
                time = 0;
                player.SetActive(true);

                for (int i = 0; i < build.GetComponent<NewBuildSystem>().totalTowerIndex; i++)
                {
                    towers[i].GetComponent<TowerBase>().isInBed(true);
                }

                inBed = false;
            }
        }
    }
}
