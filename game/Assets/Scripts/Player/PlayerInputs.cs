using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    NewControls newControls;

    public Vector2 walkInput;
    public bool placeInput;
    public bool interactInput;

    private void OnEnable()
    {
        if (newControls == null)
        {
            newControls = new NewControls();

            newControls.Movement.Walking.performed += w => walkInput = w.ReadValue<Vector2>();
            newControls.Movement.Walking.canceled += i => walkInput = new Vector2(0, 0);

            newControls.Building.Placement.performed += e => placeInput = true;
            newControls.Building.Placement.canceled += f => placeInput = false;

            newControls.Building.Interacting.performed += es => interactInput = true;
            newControls.Building.Interacting.canceled += ef => interactInput = false;
        }
        newControls.Enable();
    }
}
