using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotwheelsDamage : TowerBase
{
    public GameObject car;

    private void Start()
    {
        damage = towerData.damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<Enemy>().Damage(damage);
        }

        Destroy(car, 5f);
    }
}
