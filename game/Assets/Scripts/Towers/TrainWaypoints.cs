using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainWaypoints : MonoBehaviour
{
    public GameObject trainTower;

    public Transform[] wpoints;

    public Transform spawnpoint;
    void Start()
    {
        trainTower.GetComponent<TrainTower>().waypoints = wpoints;
        Instantiate<GameObject>(trainTower, spawnpoint);
    }
}
