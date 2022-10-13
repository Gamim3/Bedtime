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

    public bool[] getTower;
    public bool towerAbleToPlace;
    //de 2 bools hierboven zijn een test
    void Update()
    {
        getTower = GameObject.Find("ShopTest").GetComponent<Shop>().getTower;
        //voor nu bestaat de array getTower uit 3 boolians.

        if (getTower[2] == true)
        {
            tower = GameObject.Find("Tower");
            towerAbleToPlace = true;
            //getTower is een array die elke verschillende tower checkt of ze geplaatst mogen worden na aankoop, het gameobject "tower"
            //wordt bepaald door welk object is gekocht.
        }

        if (getTower[1] == true)
        {
            //tower = andere toren dan whee.
            //towerPlace = true;
        }

        towerReGetTime += Time.deltaTime;

        if (towerReGetTime < towerregret)
        {
            towerReGetTime = 0f;
            hasTower = true;
        }

        if (hasTower && towerAbleToPlace)
        {
            GetTowerInfo();
        }

        arrowPlacer.transform.position = new Vector3(posX, posY, posZ);
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
                    arrowRenderer.material.color = Color.blue;
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
                    Instantiate<GameObject>(tower, arrowHit.point, Quaternion.identity);
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
                    arrowRenderer.material.color = Color.magenta;

                    if (waitTimeForDelete > timeToDestroy)
                    {
                        waitTimeForDelete = 0;

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
        }
    }
    public void GetTowerInfo()
    {
        towerSize = tower.GetComponent<TowerBase>().towerData.size;
        placeTag = tower.GetComponent<TowerBase>().towerData.placeTag;
    }
}