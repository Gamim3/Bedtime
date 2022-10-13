using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    public TowerSO towerData;

    public float range;
    public int damage;
    public float fireRate;
    public float cost;
    public float size;
    public string placeTag;
    public LayerMask enemiesLayer;
}