using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    public TowerSO towerData;
    public GameObject[] enemyOnTrap;

    public float range;
    public float damage;
    public float fireSpeed;

    public float health;

    public bool enemyIsOnTrap;

    public int enemyNumber;

    private void Start()
    {
        range = towerData.range;
        damage = towerData.damage;
        fireSpeed = towerData.fireSpeed;
        health = towerData.health;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            print("inrange");

            //enemyOnTrap[enemyNumber] = other.gameObject;
            //enemyNumber++;

            enemyIsOnTrap = true;
            //enemyOnTrap.GetComponent<Enemy>().Health()
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            // remove enemy

            enemyOnTrap[0] = null;
        }
    }
    private void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
        if (enemyIsOnTrap == true)
        {
            AttackEnemyOnTrap();
        }
    }
    public void AttackEnemyOnTrap()
    {
        //health -= 1;

        // damage enemy after an amount of time

    }
}
