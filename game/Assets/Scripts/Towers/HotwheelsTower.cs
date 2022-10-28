using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotwheelsTower : TowerBase
{
    public GameObject car;
    public Transform spawnpoint;
    void Start()
    {
        range = towerData.range;
        damage = towerData.damage;
        fireRate = towerData.fireSpeed;
        cost = towerData.cost;
        size = towerData.size;

        isntInBed = true;
    }

    private void Update()
    {
        if (isntInBed)
        {
            Instantiate(car, spawnpoint);
        }
    }
}
