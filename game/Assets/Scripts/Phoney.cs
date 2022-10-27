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

    public Transform phoneTransform;
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
                phoneTransform = phoneyClone.transform;
            }
        }
        
        if (phoneyClone != null)
        {
            PhoneMovement();
        }
    }

    public void PhoneMovement()
    {
        if (Vector3.Distance(phoneTransform.position, waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;
            phoneRotationQ = Quaternion.LookRotation(waypoints[waypointIndex].transform.position - transform.position);
        }
        phoneTransform.position = Vector3.MoveTowards(phoneTransform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);
        phoneTransform.rotation = Quaternion.Lerp(phoneTransform.rotation, phoneRotationQ, Time.deltaTime * turnSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
