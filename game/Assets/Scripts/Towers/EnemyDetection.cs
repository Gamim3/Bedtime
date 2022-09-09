using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public TowerSO towerStats;
    public RaycastHit enemyHit;
    public bool b;

    public LayerMask enemyMask;
    private void Start()
    {
        //towerStats.GetComponent<TowerSO>();
    }
    private void Update()
    {
        if (b == true)
        {
            print(towerStats.towerCost);
            print(towerStats.towerDamage);
            print(towerStats.towerFireSpeed);
            print(towerStats.towerRange);
            b = false;
        }
    }
    void CheckForEnemies()
    {
        Collider[] EnemiesInRange = (Physics.OverlapSphere(towerStats.towerTransform.position, towerStats.towerRange, towerStats.enemyMask));

    }
}
