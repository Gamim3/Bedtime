using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBase : MonoBehaviour
{
    public bool inShopBase;
    public GameObject gameOverScene;
    public Slider Slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Slider.value == 0)
        {
            gameOverScene.SetActive(true);
        }
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
