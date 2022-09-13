using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TowerStats", menuName = "TowerScriptableObjects", order = 1)]
public class TowerSO : ScriptableObject
{
    public float towerRange;
    public float towerDamage;
    public float towerFireSpeed;
    public float towerCost;
    public Transform towerTransform;
}

