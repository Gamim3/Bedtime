using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheeTower : TowerBase
{
    public Transform target;
    public Transform towerRotation;
    public Transform towerpivot;

    public float rotateSpeed;
    void Start()
    {
        range = towerData.range;
        damage = towerData.damage;
        fireRate = towerData.fireSpeed;
        cost = towerData.cost;
        size = towerData.size;

        isntInBed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isntInBed)
        {
            GetEnemies();
            GetTarget();
            Attack();
        }
    }
    public void Attack()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - towerpivot.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(towerRotation.rotation, lookrotation, Time.deltaTime * rotateSpeed).eulerAngles;
        towerRotation.rotation = Quaternion.Euler (0f, rotation.y, 0f);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(towerTransform.position, range);
    }
    public void GetTarget()
    {
        for(int i = 0; i < enemiesInRange.Length; i++)
        {
            if (target == null)
            {
                target = enemiesInRange[i].GetComponent<Enemy>().enemyTranform;
            }
            if (enemiesInRange[i].GetComponent<Enemy>().enemyHealth < enemiesInRange[i - 1].GetComponent<Enemy>().enemyHealth)
            {
                target = enemiesInRange[i].GetComponent<Enemy>().enemyTranform;
            }
        }
    }
}