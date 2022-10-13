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
        range = towerData.range;
        damage = towerData.damage;
        fireRate = towerData.fireSpeed;
        cost = towerData.cost;
        size = towerData.size;
        placeTag = towerData.placeTag;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            waittime += Time.deltaTime;

            if (waittime > fireRate)
            {
                collision.transform.GetComponent<Enemy>().Damage(damage);
                waittime = 0;
            }
        }
    }
}