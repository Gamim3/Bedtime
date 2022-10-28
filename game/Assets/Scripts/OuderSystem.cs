using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuderSystem : MonoBehaviour
{
    public float range;
    public float exposed;
    public float maxexposed;
    public bool candotimer;

    public GameObject bed;
    private void Update()
    {
        if (candotimer)
        {
            exposed += Time.deltaTime;
        }

        if (exposed >= maxexposed)
        {
            bed.GetComponent<Bed>().inBed = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            candotimer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            candotimer = false;
        }
    }
    
}
