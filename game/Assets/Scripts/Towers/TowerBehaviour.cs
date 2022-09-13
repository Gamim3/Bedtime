using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public TowerSO towerData;

    public Transform target;

    public LayerMask enemyMask;

    public Collider[] enemyData;
    public enum TargetType
    {
        first,
        last,
        closest,
        strongest,
        weakest,
    }

    private void Start()
    {

    }
    public void TowerDetection()
    {
        enemyData = Physics.OverlapSphere(towerData.towerTransform.position, towerData.towerRange, enemyMask);

        for (int i = 0; i <= enemyData.Length; i++)
        {
            if (enemyData[i].CompareTag("enemy"))
            {
                print(enemyData[i].name);
                //target specific enemy
            }
        }
    }
    public void Shoot()
    {

    }
    public void Tracking()
    {

    }
    private void Update()
    {
        TowerDetection();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, towerData.towerRange);
    }
}
