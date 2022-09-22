using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBuildSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject tower;
    public GameObject arrowPlacer;
    public Renderer arrowRenderer;
    public GameObject cam;

    public RaycastHit playerHit;
    public RaycastHit arrowHit;
    public RaycastHit[] sphereHit;

    public float placeRange;

    public float posX;
    public float posY;
    public float posZ;

    public float distanceToArrow;

    public bool canPlace;
    public bool canDestroy;
    public bool inPlaceRange;
    public bool hasTower;
    public bool inWall;
    public bool inTower;

    public Vector3 raycastOrigin;

    public GameObject objectToDestroy;

    public string placeTag;
    public string nonPlaceTag;

    public float towerSize;

    public float waitTimeForDelete;
    public float timeToDestroy;
    void Update()
    {
        arrowPlacer.transform.position = new Vector3(posX, posY, posZ);
        distanceToArrow = Vector3.Distance(player.transform.position, arrowPlacer.transform.position);

        if (distanceToArrow < placeRange)
        {
            inPlaceRange = true;
        }
        else
        {
            inPlaceRange = false;

            posX = 100f;
            posZ = 100f;
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out playerHit, placeRange))
        {
            arrowPlacer.SetActive(true);

            posX = playerHit.point.x;
            posZ = playerHit.point.z;

            if (playerHit.transform.CompareTag("tower"))
            {
                posX = playerHit.transform.position.x;
                posZ = playerHit.transform.position.z;
            }
        }

        if (Physics.Raycast(raycastOrigin, -arrowPlacer.transform.up, out arrowHit, 3f))
        {
            arrowPlacer.SetActive(true);
        }
        else
        {
            arrowPlacer.SetActive(false);
        }

        Debug.DrawRay(arrowPlacer.transform.position, -arrowPlacer.transform.up, Color.red);

        raycastOrigin.x = arrowPlacer.transform.position.x;
        raycastOrigin.y = arrowPlacer.transform.position.y;
        raycastOrigin.z = arrowPlacer.transform.position.z;

        raycastOrigin.y += 1f;

        sphereHit = Physics.SphereCastAll(arrowHit.point, 1f, -arrowPlacer.transform.up);
        for (int i = 0; i < sphereHit.Length; i++)
        {
            if (sphereHit[i].collider.CompareTag("wall"))
            {
                print("wall");
                inWall = true;
                arrowRenderer.material.color = Color.black;
            }
            else
            {
                inWall = false;
            }

            if (sphereHit[i].collider.CompareTag("tower"))
            {
                print("tower");
                inTower = true;
                canDestroy = true;
                arrowRenderer.material.color = Color.blue;
            }
            else
            {
                inTower = false;
                canDestroy = false;
            }

            if (inWall == false && inTower == false)
            {
                // VRAGEN VOOR OPLOSSING
                if (arrowHit.transform.CompareTag(placeTag))
                {
                    canPlace = true;
                    arrowRenderer.material.color = Color.green;
                }
                else
                {
                    canPlace = false;
                    arrowRenderer.material.color = Color.red;
                }
            }
        }

        if (canPlace && hasTower && inTower == false && inWall == false)
        {
            if (player.GetComponent<PlayerInputs>().placeInput)
            {
                Instantiate<GameObject>(tower, arrowHit.point, Quaternion.identity);
                hasTower = false;
            }
        }

        if (canDestroy && inTower)
        {
            if (player.GetComponent<PlayerInputs>().interactInput)
            {
                waitTimeForDelete += Time.deltaTime;
                arrowRenderer.material.color = Color.magenta;

                if (waitTimeForDelete > timeToDestroy)
                {
                    waitTimeForDelete = 0;

                    objectToDestroy = arrowHit.transform.gameObject;
                    Destroy(objectToDestroy);
                }
            }
        }

        //    
        //    {
        //        if (arrowHit.transform.CompareTag("tower"))
        //        {
        //            canPlace = false;
        //            canDestroy = true;
        //        }
        //    }

        //    if (Physics.Raycast(cam.transform.position, cam.transform.forward, out playerHit, placeRange))
        //    {
        //        arrowPlacer.SetActive(true);

        //        posX = playerHit.point.x;
        //        posZ = playerHit.point.z;

        //        if (playerHit.transform.CompareTag("tower"))
        //        {
        //            posX = playerHit.transform.position.x;
        //            posZ = playerHit.transform.position.z;
        //        }
        //    }
        //    else
        //    {
        //        arrowPlacer.SetActive(false);
        //    }

        //    if (arrowHit.transform.CompareTag(placeTag))
        //    {

        //        canPlace = true;
        //    }
        //    else
        //    {
        //        canPlace = false;
        //    }

        //    if (arrowHit.transform.CompareTag(nonPlaceTag))
        //    {
        //        canPlace = false;
        //    }

        //    if (canDestroy)
        //    {
        //        if (arrowHit.transform.CompareTag("tower"))
        //        {
        //            if (player.GetComponent<PlayerInputs>().interactInput)
        //            {
        //                waitTimeForDelete += Time.deltaTime;

        //                if (waitTimeForDelete > 1)
        //                {
        //                    waitTimeForDelete = 0;

        //                    objectToDestroy = arrowHit.transform.gameObject;
        //                    Destroy(objectToDestroy);
        //                }
        //            }
        //            else
        //            {
        //                waitTimeForDelete = 0;
        //            }
        //        }
        //    }

        //    if (canPlace && inPlaceRange && hasTower && inWall == false)
        //    {
        //        if (player.GetComponent<PlayerInputs>().placeInput)
        //        {
        //            Instantiate<GameObject>(tower, arrowHit.point, Quaternion.identity);
        //            canPlace = false;
        //        }
        //    }
        //}
        //public void AddTowerData()
        //{
        //    placeTag = tower.GetComponent<TowerSO>().placeTag;
        //    nonPlaceTag = tower.GetComponent<TowerSO>().nonPlaceTag;

        //    hasTower = true;
    }
}
