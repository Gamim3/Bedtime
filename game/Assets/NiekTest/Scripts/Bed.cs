using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bed : MonoBehaviour
{
    public bool ableToGoInBed;
    public GameObject bedCam;
    public bool inBed;
    public GameObject message;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (inBed && Input.GetButtonDown("Jump"))
        {
            bedCam.SetActive(false);
            inBed = false;
        }

        if (Input.GetButtonDown("Jump") && ableToGoInBed)
        {
            bedCam.SetActive(true);
            inBed = true;
            ableToGoInBed = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            ableToGoInBed = true;
            message.SetActive(true);
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            ableToGoInBed = false;
            message.SetActive(false);
        }
    }
}
