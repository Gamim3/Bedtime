using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject detection;

    public RaycastHit rayHit;
    public RaycastHit sphereHit;

    public GameObject cam;

    public float reachLenght;

    public GameObject objectToMove;
    public GameObject objectToPlace;

    public float posY;

    public LayerMask grid;

    public bool canPlace;
    public bool canDestroy;
    public bool hasTower;

    public GameObject placePoint;
    public RaycastHit placeHit;
    public float placeLenght;

    private void Start()
    {
        canPlace = true;

        placeLenght = 2f;
    }
    private void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rayHit, reachLenght))
        {
            //print(rayHit.point);

            int posX = (int)Mathf.Round(rayHit.point.x);
            int posZ = (int)Mathf.Round(rayHit.point.z);

            objectToMove.transform.position = new Vector3(posX, posY, posZ);
        }

        if (player.GetComponent<PlayerInputs>().placeInput == true)
        {
            if (hasTower == true)
            {
                if (canPlace == true)
                {
                    if (Physics.Raycast(placePoint.transform.position, -placePoint.transform.up, out placeHit, placeLenght))
                    {
                        if (placeHit.transform.tag == ("placeableGround"))
                        {
                            Instantiate<GameObject>(objectToPlace, objectToMove.transform.position, Quaternion.identity);

                            canPlace = false;
                            hasTower = false;
                        }
                    }
                }
            }
        }
        if (player.GetComponent<PlayerInputs>().interactInput == true)
        {
            if (canDestroy == true)
            {
                GameObject objectToDestroy = detection.GetComponent<DetectionSystem>().destroyableObject;
                Destroy(objectToDestroy);
                canDestroy = false;
                canPlace = true;
            }
        }
    }
}
