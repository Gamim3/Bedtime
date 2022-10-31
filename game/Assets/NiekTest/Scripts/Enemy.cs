using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyStats stats;
    public Transform enemyTranform;
    public float enemySpeed;
    public int enemyHealth;

    public Waypoints Wpoints;
    public int waypointIndex;

    private Slider slider;
    public float damageTimer;
    public float currency;

    public float[] enemyCounter;
    private Animator animator;
    public float distance;

    public float turnSpeed;
    public Quaternion enemyRotation;

    private bool damage;

    void Update()
    {
        speed();
        animator = gameObject.GetComponent<Animator>();
        if (damage)
        {
            doingDamage();
        }
    }

    void Start()
    {
        //Wpoints = GameObject.FindGameObjectWithTag("waypoint").GetComponent<Waypoints>();
        enemySpeed = stats.speed;
        enemyHealth = stats.health;
    }

    void doingDamage()
    {
        slider = GameObject.FindGameObjectWithTag("Health").GetComponent<Slider>();
        animator.SetBool("attack", true);
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
        distance = Vector3.Distance(transform.position, Wpoints.waypoints[waypointIndex].position);
        if (Vector3.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;
            enemyRotation = Quaternion.LookRotation(Wpoints.waypoints[waypointIndex].transform.position - transform.position);
        }
        transform.position = Vector3.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, enemySpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, enemyRotation, Time.deltaTime * turnSpeed);
    }
    
    
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "baseDoor" && gameObject.transform != null)
        {
            damage = true;
        }
    }

    public void Damage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {

            currency = currency + stats.value;
            enemySpeed = 0;
            animator.SetBool("noHP", true);

            if (stats.enemyType == 1)
            {
                enemyCounter[0] ++;
            }

            if (stats.enemyType == 2)
            {
                enemyCounter[1] ++;
            }

            if (stats.enemyType == 3)
            {
                enemyCounter[2] ++;
            }

            if (stats.enemyType == 4)
            {
                enemyCounter[3] ++;
            }

            GameObject.Find("ShopTest").GetComponent<Shop>().currency += currency;
            for (int i = 0; i < enemyCounter.Length; i++)
            {
                GameObject.Find("Spawnpoint").GetComponent<Spawning>().counter[i] -= enemyCounter[i];
            }

        }
    }
    public void SlowDownEnemy(float damage)
    {
        enemySpeed -= 0.5f;

        StartCoroutine(RefastEnemy(3f));
    }
    public IEnumerator RefastEnemy(float time)
    {
        yield return new WaitForSeconds(time);

        enemySpeed = stats.speed;
    }

    public void Stun()
    {
        enemySpeed = 0;

        StartCoroutine(RefastEnemy(0.5f));
    }

    public void PrintEvent(string animationEnd)
    {
        if(animationEnd.Equals("dead"))
        {
            Destroy(gameObject);
        }
    }
}

