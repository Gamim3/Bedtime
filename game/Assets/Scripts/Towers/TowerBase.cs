using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    public bool isntInBed;
    public TowerSO towerData;

    public float range;
    public int damage;
    public float fireRate;
    public float cost;
    public float size;
    public string placeTag;
    public LayerMask enemiesLayer;

    public GameObject[] enemies;
    public RaycastHit[] enemyDetectionHit;
    public Transform towerTransform;
    public int indexterst;

    public Collider[] enemiesInRange;

    public Transform target;
    public float towerDistance;
    public int i;

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
    public void GetEnemies()
    {
        enemiesInRange = Physics.OverlapSphere(towerTransform.position, range, enemiesLayer);
    }
}