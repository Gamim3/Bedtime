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

    public TargetType targetType;

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

        #region
        if (towerData.targetType == 0)
        {
            targetType = TargetType.First;
        }
        if (towerData.targetType == 1)
        {
            targetType = TargetType.Close;
        }
        if (towerData.targetType == 2)
        {
            targetType = TargetType.Strong;
        }
        if (towerData.targetType == 3)
        {
            targetType = TargetType.Weak;
        }
        if (towerData.targetType == 4)
        {
            targetType = TargetType.Last;
        }
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
                newDistance = enemiesInRange[i].GetComponent<Enemy>().distance;
                newWaypoint = enemiesInRange[i].GetComponent<Enemy>().waypointIndex;
            }
        }
    }

    public void Targeting()
    {
        switch (targetType)
        {
            case TargetType.First:
                if (newWaypoint > oldWaypoints)
                {
                    // IF the new enemy's distance to waypoint is lower than the old enemy's distance to waypoint then
                    if (newDistance < oldDistance)
                    {
                        // IF enemy is closest to end of the path

                        oldWaypoints = newWaypoint;
                        oldDistance = newDistance;


                    }
                }
                break;
            case TargetType.Close:
                break;
            case TargetType.Strong:
                break;
            case TargetType.Weak:
                break;
            case TargetType.Last:
                if (newWaypoint < oldWaypoints)
                {
                    // IF the new enemy's distance to waypoint is higer than the old enemy's distance to waypoint then
                    if (newDistance > oldDistance)
                    {
                        // IF enemy is closest to begin of the path

                        oldWaypoints = newWaypoint;
                        oldDistance = newDistance;


                    }
                }
                break;
        }
    }
}
