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
    public RaycastHit sphereHit;

    public float placeRange;

    public float posX;
    public float posY;
    public float posZ;

    public float distanceToArrow;

    public bool canPlace;
    public bool canDestroy;
    public bool inPlaceRange;
    public bool hasTower;
    public bool insideWall;

    public Vector3 raycastOrigin;

    public GameObject objectToDestroy;

    public string placeTag;
    public string nonPlaceTag;

    public float towerSize;

    public float waitTimeForDelete;
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

        Debug.DrawRay(arrowPlacer.transform.position, -arrowPlacer.transform.up, Color.red);

        raycastOrigin.x = arrowPlacer.transform.position.x;
        raycastOrigin.y = arrowPlacer.transform.position.y;
        raycastOrigin.z = arrowPlacer.transform.position.z;

        raycastOrigin.y += 1f;

        //if (Physics.SphereCast(arrowHit.point, 20f, arrowPlacer.transform.up, out sphereHit))
        //{
        //    print("haha");
        //}

        if (Physics.Raycast(raycastOrigin, -arrowPlacer.transform.up, out arrowHit, 3f))
        {
            if (arrowHit.transform.CompareTag("tower"))
            {
                arrowRenderer.material.color = Color.blue;

                canPlace = false;
                canDestroy = true;
            }
            else
            {
                arrowRenderer.material.color = Color.green;
            }

            if (arrowHit.transform.CompareTag("wall"))
            {
                insideWall = true;
                arrowRenderer.material.color = Color.red;
            }
            else
            {
                insideWall = false;
            }
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
        else
        {
            arrowPlacer.SetActive(false);
        }

        if (arrowHit.transform.CompareTag(placeTag))
        {
            arrowRenderer.material.color = Color.green;
            canPlace = true;
        }
        else
        {
            canPlace = false;
        }

        if (arrowHit.transform.CompareTag(nonPlaceTag))
        {
            arrowRenderer.material.color = Color.red;
            canPlace = false;
        }

        if (canDestroy)
        {
            if (arrowHit.transform.CompareTag("tower"))
            {
                if (player.GetComponent<PlayerInputs>().interactInput)
                {
                    waitTimeForDelete += Time.deltaTime;

                    if (waitTimeForDelete > 1)
                    {
                        waitTimeForDelete = 0;

                        objectToDestroy = arrowHit.transform.gameObject;
                        Destroy(objectToDestroy);
                    }
                }
                else
                {
                    waitTimeForDelete = 0;
                }
            }
        }

        if (canPlace && inPlaceRange && hasTower && insideWall == false)
        {
            if (player.GetComponent<PlayerInputs>().placeInput)
            {
                Instantiate<GameObject>(tower, arrowHit.point, Quaternion.identity);
                canPlace = false;
            }
        }
    }
    public void AddTowerData()
    {
        placeTag = tower.GetComponent<TowerSO>().placeTag;
        nonPlaceTag = tower.GetComponent<TowerSO>().nonPlaceTag;

        hasTower = true;
    }
}
