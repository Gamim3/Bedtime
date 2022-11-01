using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuderSystem : MonoBehaviour
{
    public float exposed;
    public float maxexposed;
    public bool candotimer;

    public GameObject bed;

    public Transform player;
    public Transform ouder;

    public RaycastHit hit;

    public int spawnint;

    public Transform[] randomtransforms;
    private void Update()
    {
        Debug.DrawRay(ouder.position, player.position - ouder.position);
        if (candotimer)
        {
            exposed += Time.deltaTime;
        }

        if (exposed >= maxexposed)
        {
            bed.GetComponent<Bed>().inBed = true;
        }
    }

    public void LookingPointSpawn()
    {
        spawnint = Random.Range(0, 3);

        ouder = randomtransforms[spawnint];


    }
    private void OnTriggerEnter(Collider other)
    {
        if (Physics.Raycast(ouder.position, player.position - ouder.position, out hit, 800) && hit.transform.CompareTag("player"))
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
