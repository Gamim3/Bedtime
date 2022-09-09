using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public TowerSO towerStats;
    public RaycastHit enemyHit;
    public bool b;

    public LayerMask enemyMask;

    public int targetingType;
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
        for(int i = 0; i < EnemiesInRange.Length; i++)
        {

        }
    }

    void SearchForEnemy()
    {
        switch (targetingType)
        {
            case 0: // frist enemy
                break;
            case 1: // last
                break;
            case 2: // close
                break;
            case 3: // strong
                break;
            case 4: // weak
                break;
        }
    }
}
