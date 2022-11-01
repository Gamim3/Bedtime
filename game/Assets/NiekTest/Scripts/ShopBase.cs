using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBase : MonoBehaviour
{
    public bool inShopBase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

 
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            inShopBase = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            inShopBase = false;
        }
    }

}
