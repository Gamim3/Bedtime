using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 51)]
public class EnemyStats : ScriptableObject
{
    public int health;
    public int value;
    public int attackDamage;
    public int speed;
}
