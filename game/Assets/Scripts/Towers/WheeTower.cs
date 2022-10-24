using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class WheeTower : TowerBase
{
    private void Start()
    {
        isntInBed = true;
    }
    private void Update()
    {
        if (isntInBed)
        {
            GetEnemies();
            Targeting();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, range);
    }
}

