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

    private Slider slider;
    public float damageTimer;

    void Update()
    {
        speed();
    }

    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("waypoint").GetComponent<Waypoints>();
        enemySpeed = stats.speed;
    }

    void damage()
    {
        enemySpeed = 0;
        damageTimer += Time.deltaTime;
        if (damageTimer > 1)
        {
            slider.value -= stats.damage;
            damageTimer = 0;
        }

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

    void value()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "baseDoor" && gameObject.transform != null)
        {
            slider = GameObject.FindGameObjectWithTag("Health").GetComponent<Slider>();
            damage();
        }
    }
}
