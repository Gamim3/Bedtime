using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public GameObject player;

    public RaycastHit hit;
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
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, reachLenght))
        {
            print(hit.point);

            int posX = (int)Mathf.Round(hit.point.x);
            int posZ = (int)Mathf.Round(hit.point.z);

            objectToMove.transform.position = new Vector3(posX, posY, posZ);
        }
        if (player.GetComponent<PlayerInputs>().placeInput == true)
        {
            Instantiate<GameObject>(objectToPlace, objectToMove.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
