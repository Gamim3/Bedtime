using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheeTower : TowerBase
{
    public Transform target;
    public Transform partToRotate;
    public float rotationSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            target = other.transform;
        }
    }
    private void Update()
    {
        if (target == null){
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookrotation, Time.deltaTime * 10f).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, range);
    }
}
