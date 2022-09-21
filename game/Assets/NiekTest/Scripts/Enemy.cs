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

    void damage()
    {
        
        slider.value -= stats.damage;

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

    void value()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "baseDoor" && gameObject.transform != null)
        {
            slider = GameObject.FindGameObjectWithTag("Health").GetComponent<Slider>();
            damage();
        }
    }
}
