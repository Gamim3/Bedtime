using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Waypoints Wpoints;
    private int waypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("waypoint").GetComponent<Waypoints>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)  
        {
            waypointIndex++;
        }
        transform.position = Vector3.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);
        transform.LookAt(Wpoints.waypoints[waypointIndex].position);
    }
}
