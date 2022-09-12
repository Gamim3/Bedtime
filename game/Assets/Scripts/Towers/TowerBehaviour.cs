using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public TowerSO towerData;

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
        Collider[] enemyData = Physics.OverlapSphere(towerData.towerTransform.position, towerData.towerRange, towerData.enemyMask);
    }
    public void Shoot()
    {

    }
    public void Tracking()
    {

    }
}
