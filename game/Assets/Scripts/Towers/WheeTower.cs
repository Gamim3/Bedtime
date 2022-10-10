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
    public int[] games;
    public float[] games2;

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
        enemiesInRange = Physics.OverlapSphere(towerTransform.position, range);

        for (i = 0; i < enemiesInRange.Length; i++)
        {
            if (enemiesInRange[i].CompareTag("enemy"))
            {
                print(enemiesInRange[i].name);
            }
        }
    }
}
