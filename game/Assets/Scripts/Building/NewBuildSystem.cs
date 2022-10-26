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

    public GameObject placeBluePrint;

    public GameObject moneyToGiveTo;

    public RaycastHit playerHit;
    public RaycastHit arrowHit;
    public RaycastHit[] sphereHit;
    public RaycastHit[] pathdetecthit;
    public float placeRange;

    public float posX;
    public float posY;
    public float posZ;

    public float distanceToArrow;

    public bool canPlace;
    public bool canDestroy;
    //public bool inPlaceRange;
    public bool hasTower;
    public bool inWall;
    public bool inTower;

    public Vector3 raycastOrigin;

    public GameObject objectToDestroy;

    public string placeTag;

    public float towerSize;

    public float waitTimeForDelete;
    public float timeToDestroy;

    public float towerReGetTime;
    public float towerregret = 1f;

    public bool arrow;
    public LayerMask towerMask;

    public bool nonplace;

    public bool towerAbleToPlace;
    //de 2 bools hierboven zijn een test
    void Update()
    {

        if (tower != null)
        {
            towerAbleToPlace = true;

            hasTower = true;

            towerData = tower.GetComponent<TowerBase>().towerData;

            if (placeBluePrint == null)
            {
                placeBluePrint = Instantiate(towerData.towerBluePrint, arrowHit.point, arrowHit.transform.rotation);
            }
        }

        if (hasTower && towerAbleToPlace)
        {
            GetTowerInfo();
        }

        arrowPlacer.transform.position = new Vector3(posX, posY, posZ);
        if (placeBluePrint != null)
        {
            placeBluePrint.transform.position = arrowPlacer.transform.position;
            placeBluePrint.transform.rotation = arrowPlacer.transform.rotation;

            arrowRenderer.enabled = false;
        }
        else
        {
            arrowRenderer.enabled = true;
        }
        distanceToArrow = Vector3.Distance(player.transform.position, arrowPlacer.transform.position);

        if (distanceToArrow < placeRange)
        {
            arrow = true;
            arrowPlacer.SetActive(true);
        }
        else
        {
            arrow = false;
            arrowPlacer.SetActive(false);
        }

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out playerHit, placeRange, towerMask))
        {
            posX = playerHit.point.x;
            posZ = playerHit.point.z;

            if (playerHit.transform.CompareTag("tower"))
            {
                posX = playerHit.transform.position.x;
                posZ = playerHit.transform.position.z;
            }
        }

        if (arrow)
        {
            if (Physics.Raycast(raycastOrigin, -arrowPlacer.transform.up, out arrowHit, 3f, towerMask))
            {
                if (arrowHit.transform.CompareTag("tower"))
                {
                    inTower = true;
                    canDestroy = true;
                    arrowRenderer.sharedMaterial.SetFloat("_Placefloat", 1);
                }
                else
                {
                    inTower = false;
                    canDestroy = false;
                }
            }

            Debug.DrawRay(arrowPlacer.transform.position, -arrowPlacer.transform.up, Color.red);

            raycastOrigin.x = arrowPlacer.transform.position.x;
            raycastOrigin.y = arrowPlacer.transform.position.y;
            raycastOrigin.z = arrowPlacer.transform.position.z;

            raycastOrigin.y += 1f;

            sphereHit = Physics.SphereCastAll(arrowHit.point, towerSize, -arrowPlacer.transform.up, towerMask);

            for (int i = 0; i < sphereHit.Length; i++)
            {
                if (sphereHit[i].collider.CompareTag(placeTag))
                {
                    canPlace = true;
                }
                if (sphereHit[i].collider.CompareTag("wall"))
                {
                    inWall = true;
                }
                if (sphereHit[i].collider.CompareTag("player"))
                {
                    inWall = true;
                }
                if (sphereHit[i].collider.CompareTag("tower"))
                {
                    inTower = true;
                }
                if (!sphereHit[i].collider.CompareTag("wall"))
                {
                    inWall = false;
                }

                if (inWall == false && inTower == false)
                {
                    if (arrowHit.transform.CompareTag(placeTag))
                    {
                        if (inWall == false)
                        {
                            canPlace = true;
                            arrowRenderer.material.color = Color.green;
                        }
                    }
                    else
                    {
                        canPlace = false;
                        arrowRenderer.material.color = Color.red;
                    }
                }
            }

            if (inWall)
            {
                arrowRenderer.material.color = Color.black;
            }

            if (canPlace && hasTower && inTower == false && inWall == false && nonplace == false && towerAbleToPlace)
            {
                if (player.GetComponent<PlayerInputs>().placeInput)
                {
                    Instantiate<GameObject>(tower, arrowHit.point, arrowPlacer.transform.rotation);
                    Destroy(placeBluePrint);
                    tower = null;
                    hasTower = false;
                    towerAbleToPlace = false;
                    //aka geen tower meer.
                }
            }

            if (canDestroy && inTower)
            {
                if (player.GetComponent<PlayerInputs>().interactInput)
                {
                    waitTimeForDelete += Time.deltaTime;
                    arrowRenderer.sharedMaterial.SetFloat("_Placefloat", 0);

                    if (waitTimeForDelete > timeToDestroy)
                    {
                        waitTimeForDelete = 0;

                        float moneytogiveback = arrowHit.transform.GetComponent<TowerBase>().towerData.cost / 2;

                        moneyToGiveTo.GetComponent<Spawning>().currency += moneytogiveback;

                        objectToDestroy = arrowHit.transform.gameObject;
                        Destroy(objectToDestroy);

                        hasTower = true;
                    }
                }
                else
                {
                    waitTimeForDelete = 0;
                }
            }

            if (player.GetComponent<PlayerInputs>().rotateInput)
            {
                transform.Rotate(0f, arrowPlacer.transform.position.y + 10 * Time.deltaTime, 0f, Space.Self);
            }
        }
    }
    
    public void GetTowerInfo()
    {
        if (tower != null)
        {
            towerSize = tower.GetComponent<TowerBase>().towerData.size;
            placeTag = tower.GetComponent<TowerBase>().towerData.placeTag;
        }
    }
}