using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyStats stats;

    private float enemySpeed;
    private float enemyHealth;

    private Waypoints Wpoints;
    private int waypointIndex;

    private Slider slider;
    public float damageTimer;
    public float currency;

    public float[] enemyCounter;

    void Update()
    {
        if(enemyHealth < 1)
        {
           
            GameObject.Find("WaveCounterManager").GetComponent<WaveCounter>().currency += currency;
            GameObject.Find("WaveCounterManager").GetComponent<WaveCounter>().counter[0] -= enemyCounter[0];
            GameObject.Find("WaveCounterManager").GetComponent<WaveCounter>().counter[1] -= enemyCounter[1];
            GameObject.Find("WaveCounterManager").GetComponent<WaveCounter>().counter[2] -= enemyCounter[2];
            GameObject.Find("WaveCounterManager").GetComponent<WaveCounter>().counter[3] -= enemyCounter[3];
            Destroy(gameObject);
            //dit kan niet in 1 array volgens unity :/  (moet gefixd worden)
        }

        speed();

    }

    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("waypoint").GetComponent<Waypoints>();
        enemySpeed = stats.speed;
        enemyHealth = stats.health;
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

    
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "baseDoor" && gameObject.transform != null)
        {
            slider = GameObject.FindGameObjectWithTag("Health").GetComponent<Slider>();
            damage();
        }
    }



    // nope dit is niet de goede manier nooit damage doen met een ontrigger enter en bullet
    /*
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            enemyHealth -= 1;
            if(stats.enemyType == 1 && enemyHealth < 1)
            {
                currency = currency + stats.value;
                enemyCounter[0] += 1;
            }

            if (stats.enemyType == 2 && enemyHealth < 1)
            {
                currency = currency + stats.value;
                enemyCounter[1] += 1;
            }

            if (stats.enemyType == 3 && enemyHealth < 1)
            {
                currency = currency + stats.value;
                enemyCounter[2] += 1;
            }

            if (stats.enemyType == 4 && enemyHealth < 1)
            {
                currency = currency + stats.value;
                enemyCounter[3] += 1;
            }
        }
    }
    */

    //meer iets als dit
    public void Damage(float damage)
    {
        print(damage);

        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
