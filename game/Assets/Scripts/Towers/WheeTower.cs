using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheeTower : TowerBase
{
    public Transform target;
    public Transform partToRotate;
    public float rotationSpeed;
    public bool isDamageDone;
    public float timeBetweenShooting;
    
    private void Start()
    {
        damage = towerData.damage;
        fireRate = towerData.fireSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isDamageDone || target == null)
        {
            if (other.CompareTag("enemy"))
            {
                target = other.transform;
                isDamageDone = false;
            }
        }
    }
    private void Update()
    {
        if (target == null){
            return;
        }
        
        timeBetweenShooting += Time.deltaTime;

        if (timeBetweenShooting >= fireRate)
        {
            DoDamage();
            timeBetweenShooting = 0f;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookrotation, Time.deltaTime * 10f).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
    }

    public void DoDamage()
    {
        target.GetComponent<Enemy>().Damage(damage);
        isDamageDone = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, range);
    }
}
