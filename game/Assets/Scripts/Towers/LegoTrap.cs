using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoTrap : TowerBase
{
    public float health;

    public RaycastHit[] enemyDetection;

    public GameObject enemyToAttack;

    public float waittime;
    private void Start()
    {
        #region
        range = towerData.range;
        damage = towerData.damage;
        fireRate = towerData.fireSpeed;
        cost = towerData.cost;
        size = towerData.size;
        placeTag = towerData.placeTag;
        #endregion
    }


    private void OnTriggerEnter(Collider other)
    {
        print("haialo");
        if (other.CompareTag("enemy"))
        {
            print("lore");
            waittime += Time.deltaTime;

            if (waittime > fireRate)
            {
                other.GetComponent<Enemy>().Damage(damage);
                waittime = 0;
            }
        }
    }
}