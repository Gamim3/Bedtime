using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    NewControls newControls;
    public Transform playerTransform;
    public Rigidbody playerRigidbody;

    [Header("statistics")]
    #region
    [SerializeField]
    private float maxWalkSpeed;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private Vector3 move;
    [SerializeField]
    #endregion
    [Header("Inputs")]
    #region
    public Vector2 walkInput;
    public bool placeInput;
    public bool interactInput;
    public bool rotateInputR;
    public bool rotateInputL;
    public bool startwaveInput;
    public bool escapeInput;

    #endregion

    private void OnEnable()
    {
        if (newControls == null)
        {
            newControls = new NewControls();

            newControls.Movement.Walking.performed += w => walkInput = w.ReadValue<Vector2>();
            newControls.Movement.Walking.canceled += i => walkInput = new Vector2(0, 0);

            newControls.Movement.Escape.performed += esc => escapeInput = true;
            newControls.Movement.Escape.canceled += esc => escapeInput = false;

            newControls.Building.Placement.performed += e => placeInput = true;
            newControls.Building.Placement.canceled += f => placeInput = false;

            newControls.Building.Interacting.performed += es => interactInput = true;
            newControls.Building.Interacting.canceled += ef => interactInput = false;

            newControls.Building.RotatingR.performed += er => rotateInputR = true;
            newControls.Building.RotatingR.canceled += ex => rotateInputR = false;

            newControls.Building.RotatingL.performed += ers => rotateInputL = true;
            newControls.Building.RotatingL.canceled += erx => rotateInputL = false;

            newControls.Building.StartWave.performed += aj => startwaveInput = true;
            newControls.Building.StartWave.canceled += ajs => startwaveInput = false;
        }
        newControls.Enable();
    }

    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        move.x = walkInput.x;
        move.z = walkInput.y;

        playerTransform.Translate(move * walkSpeed * Time.deltaTime);
    }
}