using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBuildSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject arrowPlacer;
    public Renderer arrowRenderer;
    public GameObject cam;

    public RaycastHit playerHit;
    public RaycastHit arrowHit;

    public float placeRange;

    public float posX;
    public float posY;
    public float posZ;

    public float distanceToArrow;

    public bool canPlace;
    public bool canDestroy;
    public bool inPlaceRange;

    public GameObject tower;

    public Vector3 raycastOrigin;

    public GameObject objectToDestroy;
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

        if (arrowHit.transform.CompareTag("placeableGround"))
        {
            arrowRenderer.material.color = Color.green;
            canPlace = true;
        }
        else
        {
            canPlace = false;
        }

        if (arrowHit.transform.CompareTag("nonPlaceableGround"))
        {
            arrowRenderer.material.color = Color.red;
            canPlace = false;
        }

        if (canDestroy)
        {
            if (player.GetComponent<PlayerInputs>().interactInput)
            {
                if (arrowHit.transform.CompareTag("tower"))
                {
                    objectToDestroy = arrowHit.transform.gameObject;

                    Destroy(objectToDestroy);
                }
            }
        }

        if (canPlace && inPlaceRange)
        {
            if (player.GetComponent<PlayerInputs>().placeInput)
            {
                Instantiate<GameObject>(tower, arrowPlacer.transform.position, Quaternion.identity);
                canPlace = false;
            }
        }
    }
}
