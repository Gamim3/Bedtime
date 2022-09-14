using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public GameObject shopUI;
    //public Upgrade[] upgrades;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ToggleShop()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }

    [System.Serializable]
    public class Upgrade
    {
        public string name;
        public int cost;
        public Sprite image;
        [HideInInspector] public GameObject itemRef;
    }
}
