using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public GameObject player;

    public RaycastHit rayHit;
    public RaycastHit sphereHit;

    public GameObject cam;

    public float reachLenght;

    public GameObject objectToMove;
    public GameObject objectToPlace;

    public float posY;

    public LayerMask Grid;
    


    private void Start()
    {

    }
    private void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rayHit, reachLenght))
        {
            print(rayHit.point);

            int posX = (int)Mathf.Round(rayHit.point.x);
            int posZ = (int)Mathf.Round(rayHit.point.z);

            objectToMove.transform.position = new Vector3(posX, posY, posZ);
        }
        if (player.GetComponent<PlayerInputs>().placeInput == true)
        {
            print("nummer0");

            Instantiate<GameObject>(objectToPlace, objectToMove.transform.position, Quaternion.identity);

            //if (Physics.SphereCast(objectToPlace.transform.position, 1f, objectToPlace.transform.forward, out sphereHit))
            //{
            //    print("nummer1");
            //    if (sphereHit.transform.tag == ("tower"))
            //    {
            //        print("tot hier");
            //    }
            //    else
            //    {
            //        Instantiate<GameObject>(objectToPlace, objectToMove.transform.position, Quaternion.identity);
            //    }
            //    print("checking for towers");
            //    return;
            //}
        }
    }
}
