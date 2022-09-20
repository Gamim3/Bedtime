using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTower : MonoBehaviour
{
    public TowerSO towerData;
    public float range;
    public RaycastHit hit;
    public Transform towerT;
    private void Start()
    {
        range = towerData.range;
    }
    private void Update()
    {
        Debug.DrawRay(towerT.position, towerT.forward, Color.green);

        if (Physics.Raycast(towerT.position, towerT.forward, out hit, range))
        {
            if (hit.transform.CompareTag("enemy"))
            {

            }
            if (hit.transform.CompareTag("tower"))
            {
                //cant shoot
            }
        }
    }
}
