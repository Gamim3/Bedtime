using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
    public float levens;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = levens;
    }
    void Update()
    {
        if(slider.value == 0)
        {
            //gameOverScherm
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        slider.value -= 1;
    }
}
