using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBase : MonoBehaviour
{
    public bool inShopBase;
    public GameObject gameOverScene;
    public GameObject gameUI;
    public Slider Slider;
    public GameObject inMenuScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Slider.value == 0)
        {
            gameOverScene.SetActive(true);
            inMenuScript.GetComponent<Cams>().inMenu = true;
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
