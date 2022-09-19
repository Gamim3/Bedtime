using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStats stats;

    public float enemySpeed;
    private Waypoints Wpoints;
    private int waypointIndex;

    void Update()
    {
        speed();
        enemySpeed = stats.speed;
    }

    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("waypoint").GetComponent<Waypoints>();
    }

    void health()
    {
        
    }

    void speed()
    {
        if (Vector3.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;
        }
        transform.position = Vector3.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, enemySpeed * Time.deltaTime);
        transform.LookAt(Wpoints.waypoints[waypointIndex].position);
    }

    void damage()
    {
        //stats1.AttackDamage
    }

    void value()
    {

    }

    

    

    
}
