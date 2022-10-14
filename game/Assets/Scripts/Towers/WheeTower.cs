using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class WheeTower : TowerBase
{
    private void Update()
    {
        if (isntInBed)
        {
            GetEnemies();
            Targeting();
            DoDamage();
        }
    }

    public void DoDamage()
    {
        print("IM DEAD");
    }
}   