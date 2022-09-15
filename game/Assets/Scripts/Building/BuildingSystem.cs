using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    #region
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

    public Renderer arrowMaterial;

    #endregion

    private void Start()
    {
        canPlace = true;

        placeLenght = 2f;
    }
    private void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rayHit, reachLenght))
        {
            int posX = (int)Mathf.Round(rayHit.point.x);
            int posZ = (int)Mathf.Round(rayHit.point.z);

            objectToMove.transform.position = new Vector3(posX, posY, posZ);

            if (rayHit.transform.CompareTag("tower"))
            {
                detection.SetActive(true);
            }
            if (hasTower == true)
            {
                detection.SetActive(true);
            }
        }
        else
        {
            detection.SetActive(false);
        }

        if (hasTower == true)
        {
            detection.SetActive(true);

            if (canPlace == true)
            {
                arrowMaterial.material.color = Color.green;

                if (Physics.Raycast(placePoint.transform.position, -placePoint.transform.up, out placeHit, placeLenght))
                {
                    if (placeHit.transform.tag == ("placeableGround"))
                    {
                        if (player.GetComponent<PlayerInputs>().placeInput == true)
                        {
                            Instantiate<GameObject>(objectToPlace, objectToMove.transform.position, Quaternion.identity);

                            canPlace = false;
                            hasTower = false;
                        }
                    }
                }
            }
        }

        if (canDestroy == true)
        {
            arrowMaterial.material.color = Color.red;

            if (player.GetComponent<PlayerInputs>().interactInput == true)
            {
                GameObject objectToDestroy = detection.GetComponent<BuildDetection>().destroyableObject;
                Destroy(objectToDestroy);

                canDestroy = false;
                canPlace = true;
                detection.SetActive(false);
            }
        }
    }
}
