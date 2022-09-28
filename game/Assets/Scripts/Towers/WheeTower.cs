using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheeTower : TowerBase
{
    public string targetType;
    public float detectionRange;
    public Transform towerTransform;
    public RaycastHit[] detection;
    public GameObject[] enemy;
    public int ie;

    private void Start()
    {
        range = towerData.range;
        damage = towerData.damage;
        fireRate = towerData.fireSpeed;
        cost = towerData.cost;
        size = towerData.size;
        placeTag = towerData.placeTag;
    }

    private void Update()
    {
        detection = Physics.SphereCastAll(towerTransform.position, detectionRange, towerTransform.up);

        print(detection.Length);

        for (int i = 0; i < detection.Length; i++)
        {
            enemy[i] = detection[i].transform.gameObject;
        }
    }
}
