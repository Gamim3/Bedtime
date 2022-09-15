using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 51)]
public class EnemyStats : ScriptableObject
{
    
    [SerializeField]
    private string EnemyName;
    [SerializeField]
    private float health;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int value;
    [SerializeField]
    private int attackDamage;
    

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
