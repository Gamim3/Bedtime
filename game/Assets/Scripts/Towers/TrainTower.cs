using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTower : TowerBase
{
    public Transform trainTransform;
    public Transform[] waypoints;
    public int waypointIndex;
    public Transform trainRotation;
    public float turnSpeed;
    private void Start()
    {
        isntInBed = true;
    }
    private void Update()
    {
        if (isntInBed)
        {
            trainMovement();
        }
    }
    public void trainMovement()
    {
        if (waypointIndex == 4)
        {
            waypointIndex = 0;
        }

        if (Vector3.Distance(trainTransform.position, waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;
            trainRotation.rotation = Quaternion.LookRotation(waypoints[waypointIndex].transform.position - trainTransform.position);
        }

        
        trainTransform.position = Vector3.MoveTowards(trainTransform.position, waypoints[waypointIndex].position, fireRate * Time.deltaTime);
        trainTransform.rotation = Quaternion.Lerp(transform.rotation, trainRotation.rotation, Time.deltaTime * turnSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<Enemy>().Damage(damage);
        }
    }
}
