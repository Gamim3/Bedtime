using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TowerStats", menuName = "TowerScriptableObjects", order = 1)]
public class TowerSO : ScriptableObject
{
    public float range;
    public float damage;
    public float fireSpeed;
    public float cost;

    public float health;

    public string targetType;

    public string placeTag;
    public string nonPlaceTag;
}

