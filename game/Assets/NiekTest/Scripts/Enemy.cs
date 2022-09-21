using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyStats stats;

    public float enemySpeed;
    private Waypoints Wpoints;
    public int waypointIndex;

    public bool healthBool;
    private Slider slider;

    void Update()
    {
        speed();
        enemySpeed = stats.speed;
    }

    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("waypoint").GetComponent<Waypoints>();

        //slider.value = 10;
    }

    void health()
    {
        slider.value -= stats.attackDamage;

        if (slider.value == 0)
        {
            //gameOverScherm
        }
    }

    void speed()
    {
        if (Vector3.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            if(waypointIndex < 2)
            {
                waypointIndex++;
            }
            
            else
            {
                Destroy(gameObject);
            }
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "baseDoor" && gameObject.transform != null)
        {
            
            slider = GameObject.FindGameObjectWithTag("Health").GetComponent<Slider>();
            health();
        }
    }
}
