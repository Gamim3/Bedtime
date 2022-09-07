using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float time;
    public Transform target;
    public RaycastHit hit;
    public GameObject bullet;
    public float cooldown;
    public float levensTurret;
    public float reset;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 80))
        {
            if (hit.transform.gameObject.tag == "enemy 1")

            {

                time += Time.deltaTime;
                if (time > cooldown)
                {
                    GameObject deDaadwerkelijkeBullet = Instantiate(bullet, transform.position, bullet.transform.rotation);
                    deDaadwerkelijkeBullet.transform.forward = transform.forward;

                    time = reset;

                }
            }
            else
            {
                time = reset;
            }

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bulletPlayer")
        {

            levensTurret -= 1;
            if (levensTurret == 0)
            {
                Destroy(gameObject);


            }
        }
    }
}
