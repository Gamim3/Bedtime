using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheeTower : TowerBase
{
    
    void Start()
    {
        range = towerData.range;
        damage = towerData.damage;
        fireRate = towerData.fireSpeed;
        cost = towerData.cost;
        size = towerData.size;

        isntInBed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isntInBed)
        {
            GetEnemies();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(towerTransform.position, range);
    }
}
