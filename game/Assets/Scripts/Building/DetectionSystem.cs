using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSystem : MonoBehaviour
{
    public GameObject buildingSystem;
    private void OnTriggerEnter(Collider other)
    {
        print("colliding");

        if (other.tag == ("tower"))
        {
            buildingSystem.GetComponent<BuildingSystem>().canPlace = false; 
        }
        else
        {
            buildingSystem.GetComponent<BuildingSystem>().canPlace = true;
        }
    }
}
