using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PherbTower : TowerBase
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

    public void Update()
    {
        GetEnemies();

        
    }

    public IEnumerator DoDamageOverTime()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < enemiesInRange.Length; i++)
        {
            enemiesInRange[i].GetComponent<Enemy>().Damage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(towerTransform.position, range);
    }
}
