using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class WheeTower : TowerBase
{
    public GameObject[] enemies;
    public RaycastHit[] enemyDetectionHit;
    public Transform towerTransform;
    public int indexterst;

    public Collider[] enemiesInRange;

    public Transform target;
    public float towerDistance;
    public int i;

    public int newWaypoint;
    public int oldWaypoints;
    public float newDistance;
    public float oldDistance;

    // Start is called before the first frame update
    void Start()
    {
        #region
        range = towerData.range;
        damage = towerData.damage;
        fireRate = towerData.fireSpeed;
        cost = towerData.cost;
        size = towerData.size;
        #endregion
    }

    public enum TargetType
    {
        First,
        Close,
        Strong,
        Weak,
        Last
    }
    // Update is called once per frame
    private void Update()
    {
        enemiesInRange = Physics.OverlapSphere(towerTransform.position, range, enemiesLayer);

        for (i = 0; i < enemiesInRange.Length; i++)
        {
            if (enemiesInRange[i].CompareTag("enemy"))
            {
                //THIS WORKS target = enemiesInRange[i].GetComponent<Enemy>().enemyTranform; THIS WORKS

                newDistance = enemiesInRange[i].GetComponent<Enemy>().distance;
                newWaypoint = enemiesInRange[i].GetComponent<Enemy>().waypointIndex;

                if (target == null)
                {
                    target = enemiesInRange[i].GetComponent<Enemy>().enemyTranform;
                    oldDistance = newDistance;
                    oldWaypoints = newWaypoint;
                }
                else
                {
                    // ask how to check for the last one
                    if (oldWaypoints < newWaypoint)
                    {
                        print("smaller");
                        
                        if (oldDistance < newDistance)
                        {
                            print("complete");
                            oldWaypoints = newWaypoint;
                            oldDistance = newDistance;
                        }
                    }
                }
            }
        }
    }
}
