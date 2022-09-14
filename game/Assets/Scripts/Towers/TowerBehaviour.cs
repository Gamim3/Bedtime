using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public TowerSO towerData;

    public Transform target;

    public LayerMask enemyMask;

    public Collider[] enemyData;

    public Transform towerTransform;

    public string targetingType;

    private void Start()
    {
        targetingType = towerData.targetType;
    }
    public void TowerDetection()
    {
        enemyData = Physics.OverlapSphere(towerTransform.position, towerData.range, enemyMask);

        for (int i = 1; i < enemyData.Length; i++)
        {
            if (enemyData[i].CompareTag("enemy"))
            {
                print(enemyData[i].name);
                //target specific enemy

                if (targetingType == ("first"))
                {
                    
                }
                
            }
            else
            {
                return;
            }
        }
    }
    private void Update()
    {
        TowerDetection();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, towerData.range);
    }
}
