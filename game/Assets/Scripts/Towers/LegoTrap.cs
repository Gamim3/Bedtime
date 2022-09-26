using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoTrap : TowerBase
{
    public float health;

    public RaycastHit[] enemyDetection;

    public GameObject enemyToAttack;
    private void Update()
    {
        enemyDetection = Physics.SphereCastAll(transform.position, 3f, transform.up);

        for (int i = 0; i < enemyDetection.Length; i++)
        {
            if (enemyDetection[i].collider.CompareTag("enemy"))
            {
                enemyToAttack = enemyDetection[i].collider.gameObject;
            }
        }

        StartCoroutine(TrapAttack(fireRate));
    }

    public IEnumerator TrapAttack(float waitTime)
    {
        yield return new WaitForSeconds(fireRate);

        // do damage to enemy on spike trap;

        //enemyToAttack.GetComponent<Enemy>().

        // do damage to trap
    }
}