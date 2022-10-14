using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuttyTrap : TowerBase
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            waittime += Time.deltaTime;

            if (waittime > fireRate)
            {
                other.GetComponent<Enemy>().enemySpeed -= 1;
                other.GetComponent<Enemy>().Damage(damage);
                waittime = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("enemy"))
        {
            other.GetComponent<Collider>().GetComponent<Enemy>().enemySpeed += 1;
        }
    }
}