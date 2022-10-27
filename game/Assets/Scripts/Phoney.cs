using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phoney : MonoBehaviour
{
    public GameObject inputs;

    public int damage;
    public float speed;

    public GameObject phoneyOBJ;
    public GameObject phoneyClone;

    public Quaternion phoneRotationQ;

    public Transform[] waypoints;
    public int waypointIndex;

    public float turnSpeed;

    private void Update()
    {
        if (inputs.GetComponent<PlayerInputs>().interactInput)
        {
            if (phoneyClone == null)
            {
                phoneyClone = Instantiate(phoneyOBJ, this.transform);
            }
        }
        
        if (phoneyClone != null)
        {
            PhoneMovement();
        }
    }

    public void PhoneMovement()
    {
        if (waypointIndex == 0)
        {
            phoneRotationQ = Quaternion.LookRotation(waypoints[waypointIndex].transform.position - transform.position);
        }
        //distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;
            phoneRotationQ = Quaternion.LookRotation(waypoints[waypointIndex].transform.position - transform.position);
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, phoneRotationQ, Time.deltaTime * turnSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
