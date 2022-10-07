using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheeTower : TowerBase
{
    public GameObject[] enemies;
    public RaycastHit[] enemyDetectionHit;
    public Transform towerTransform;
    public int indexterst;

    public Transform target;
    public float towerDistance;

    public int i;
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

    // Update is called once per frame
    void Update()
    {
        

        enemyDetectionHit = Physics.SphereCastAll(towerTransform.position, range, towerTransform.up);

        for (i = 0; i < enemyDetectionHit.Length; i++)
        {
            if (enemyDetectionHit[i].collider.CompareTag("enemy"))
            {
                enemies[indexterst] = enemyDetectionHit[i].transform.gameObject;
                


                towerDistance = Vector3.Distance(towerTransform.position, enemies[i].transform.position);
                print(towerDistance);

                //if (towerDistance > range)
                //{
                //    enemies[i] = null;
                //}

                indexterst++;
                if (i < 5)
                {
                    i = 0;
                }
            }
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            if (i == 0)
            {
                target = enemies[i].transform;
            }
            else if (enemies[i].GetComponent<Enemy>().waypointIndex > enemies[i - 1].GetComponent<Enemy>().waypointIndex)
            {
                target = enemies[i].transform;
            }
        }
    }
}
