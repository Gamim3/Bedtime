using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotwheelsTower : TowerBase
{
    public GameObject car;
    public Transform spawnpoint;

    public GameObject carclone;
    void Start()
    {

        isntInBed = true;
    }

    private void Update()
    {
        if (isntInBed)
        {
            if (carclone == null)
            {
                carclone = Instantiate(car, spawnpoint);
                print("null");
            }
        }
    }
}
