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

    [Header("enemy targeting statistics")]
    #region
    public int newWaypoint;
    public int oldWaypoints;

    public float newDistance;
    public float oldDistance;

    public int newEnemyDamage;
    public int oldEnemyDamage;

    public int newEnemyHealth;
    public int oldEnemyHealth;

    public float newE_DistanceTo_T;
    public float oldE_DistanceTo_T;

    public float t_distanceTo_T;
    #endregion
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
                newWaypoint = enemiesInRange[i].GetComponent<Enemy>().waypointIndex;

                newDistance = enemiesInRange[i].GetComponent<Enemy>().distance;

                newEnemyDamage = enemiesInRange[i].GetComponent<Enemy>().stats.damage;

                newEnemyHealth = enemiesInRange[i].GetComponent<Enemy>().enemyHealth;

                newE_DistanceTo_T = Vector3.Distance(towerTransform.position, enemiesInRange[i].GetComponent<Enemy>().enemyTranform.position);
            }

            Targeting();

        }

        if (target != null)
        {
            t_distanceTo_T = Vector3.Distance(towerTransform.position, target.position);

            if (t_distanceTo_T > range)
            {
                target = null;
                Targeting();
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
                    if (newDistance < oldDistance)
                    {
                        // IF enemy is closest to end of the path

                        oldWaypoints = newWaypoint;
                        oldDistance = newDistance;


                        //TARGET = FURTHEST ON PATH AND IN TOWER RANGE
                    }
                }
                break;
            case TargetType.Close:
                if (newE_DistanceTo_T < oldE_DistanceTo_T)
                {
                    oldE_DistanceTo_T = newE_DistanceTo_T;
                }
                break;
            case TargetType.Strong:
                if (newEnemyDamage > oldEnemyDamage)
                {
                    oldEnemyDamage = newEnemyDamage;
                }
                break;
            case TargetType.Weak:
                if (newEnemyHealth < oldEnemyHealth)
                {
                    oldEnemyHealth = newEnemyHealth;
                }
                break;
            case TargetType.Last:
                if (newWaypoint < oldWaypoints)
                {
                    if (newDistance > oldDistance)
                    {
                        // IF enemy is closest to begin of the path

                        oldWaypoints = newWaypoint;
                        oldDistance = newDistance;


                        //TARGET = EARLIEST ON PATH AND IN TOWER RANGE
                    }
                }
                break;
        }
    }
}
