using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSystem : MonoBehaviour
{
    public GameObject buildingSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tower"))
        {
            buildingSystem.GetComponent<BuildingSystem>().canPlace = false;
        }
        if (other.CompareTag("player"))
        {
            buildingSystem.GetComponent<BuildingSystem>().canPlace = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("tower"))
        {
            buildingSystem.GetComponent<BuildingSystem>().canPlace = true;
        }
        if (other.CompareTag("player"))
        {
            buildingSystem.GetComponent<BuildingSystem>().canPlace = true;
        }
    }
}
