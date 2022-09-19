using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyStats stats;

    public float enemySpeed;
    private Waypoints Wpoints;
    private int waypointIndex;

    public bool healthBool;
    public Slider slider;

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
        slider = GameObject.Find("Health Bar").GetComponent<Slider>();

        if (slider.value == 0)
        {
            //gameOverScherm
        }
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "baseDoor")
        {
            health();
        }
    }
}
