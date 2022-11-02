using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotwheelsTower : TowerBase
{
    public GameObject carOBJ;
    public GameObject carClone;

    public Transform spawnPoint;

    public Transform[] wPoints;
    public void Spawner(int spawnamount)
    {
        if (spawnamount < 0)
        {
            if (carClone == null)
            {
                carClone = Instantiate(carOBJ, this.transform);
                carClone.GetComponent<PhoneyDamage>().waypoints = wPoints;
            }
            spawnamount--;
        }
    }
}
