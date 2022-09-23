using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBuildSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject tower;
    public TowerSO towerData;
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

    public float towerSize;

    public float waitTimeForDelete;
    public float timeToDestroy;

    void Update()
    {
        if (hasTower)
        {
            GetTowerInfo();
        }
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
            //arrowPlacer.SetActive(true);

            if (arrowHit.transform.CompareTag("tower"))
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
        }
        else
        {
            //arrowPlacer.SetActive(false);
        }

        Debug.DrawRay(arrowPlacer.transform.position, -arrowPlacer.transform.up, Color.red);

        raycastOrigin.x = arrowPlacer.transform.position.x;
        raycastOrigin.y = arrowPlacer.transform.position.y;
        raycastOrigin.z = arrowPlacer.transform.position.z;

        raycastOrigin.y += 1f;

        sphereHit = Physics.SphereCastAll(arrowHit.point, towerSize, -arrowPlacer.transform.up);

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
            else
            {
                waitTimeForDelete = 0;
            }
        }
    }
    public void GetTowerInfo()
    {
        print("hai");

        placeTag = tower.GetComponent<TowerBase>().towerData.placeTag;
    }
}
