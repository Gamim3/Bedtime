using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public GameObject target;
    public GameObject structure;
    Vector3 truePos;
    public float gridSize;

    public RaycastHit hit;
    public GameObject cam;
    public Vector3 direction;
    public float distance;
    public Vector3 point;
    public Vector3 height;

    private void Start()
    {
        distance = 3.5f;
        height.y = 1;
    }
    private void Update()
    {
        direction = cam.transform.forward;

        if (Physics.Raycast(cam.transform.position, direction, out hit, distance))
        {
            print(hit.transform.position);
            point = hit.point;

            target.transform.position = point;
            target.transform.position += height;
        }
    }
    private void LateUpdate()
    {
        truePos.x = Mathf.Floor(target.transform.position.x / gridSize) * gridSize;
        truePos.y = Mathf.Floor(target.transform.position.y / gridSize) * gridSize;
        truePos.z = Mathf.Floor(target.transform.position.z / gridSize) * gridSize;

        structure.transform.position = truePos;
    }
}
