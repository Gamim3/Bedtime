using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public TowerSO towerData;
    public float towerRange;
    public float towerDamage;
    public float towerFireSpeed;
    public float towerCost;

    public Transform towerTransform;
    public LayerMask enemyMask;


    private void Start()
    {
        towerRange = towerData.towerRange;
        towerDamage = towerData.towerDamage;
        towerFireSpeed = towerData.towerFireSpeed;
        towerCost = towerData.towerCost;
        enemyMask = towerData.enemyMask;
    }
}
