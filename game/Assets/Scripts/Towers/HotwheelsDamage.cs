using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotwheelsDamage : TowerBase
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<Enemy>().Damage(damage);
        }
        else
        {
            if (other.CompareTag("tower") || other.CompareTag("player"))
            {
                return;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
