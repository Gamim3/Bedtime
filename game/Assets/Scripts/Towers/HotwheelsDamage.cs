using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotwheelsDamage : TowerBase
{
    public GameObject car;

    public bool canDamage;


    public Transform[] waypoints;
    public int waypointIndex;
    public Quaternion phoneRotationQ;
    public float speed;
    public float turnSpeed;
    private void Start()
    {
        damage = towerData.damage;
        range = towerData.range;
        fireRate = towerData.fireSpeed;

        speed = fireRate;

    }

    private void Update()
    {
        CarMovement();
    }
    public void CarMovement()
    {
        if (waypointIndex == 0)
        {
            phoneRotationQ = Quaternion.LookRotation(waypoints[waypointIndex].transform.position - transform.position);
        }
        if (waypointIndex == waypoints.Length)
        {
            speed = 0;
            Destroy(this.gameObject);
        }

        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f && waypointIndex != 13)
        {
            waypointIndex++;
            phoneRotationQ = Quaternion.LookRotation(waypoints[waypointIndex].transform.position - transform.position);
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, phoneRotationQ, Time.deltaTime * turnSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<Enemy>().Damage(damage);
        }
    }
}
