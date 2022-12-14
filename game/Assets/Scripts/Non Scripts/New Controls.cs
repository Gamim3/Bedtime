//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Non Scripts/New Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @NewControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""a17fe769-be75-4660-93f7-e0627c28a371"",
            ""actions"": [
                {
                    ""name"": ""Walking"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ccb76c4b-51c6-405a-9f13-330cd137ed90"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""1dff5650-4a8f-4b93-b171-89318fc23363"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ba1d7aa3-afb8-4252-8727-6e74097e0e0e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3a01a89f-b778-4217-a74e-8bda8f9ca87b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b50d3b15-9a3e-4c91-9601-0ca55e022b15"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""29b3d91d-e06b-44b7-a0bd-1caaec6bc0ff"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3c3b7c5a-96c0-4775-8123-7d42ef0e63a8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c6ba9f7d-c077-4c93-a7a3-895524b586ff"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Building"",
            ""id"": ""b906b408-7dc5-40a3-8d17-7f058f35f5c4"",
            ""actions"": [
                {
                    ""name"": ""Placement"",
                    ""type"": ""Button"",
                    ""id"": ""a0b6f445-0c5b-48cb-adef-da89c1b23deb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interacting"",
                    ""type"": ""Button"",
                    ""id"": ""c98c4478-e43a-4719-af48-116011594069"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RotatingR"",
                    ""type"": ""Button"",
                    ""id"": ""3382a2b1-3d54-4a35-b26a-e022b08bbac7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotatingL"",
                    ""type"": ""Button"",
                    ""id"": ""1fba8d35-10e1-4e8a-8f9c-d3fff6682520"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StartWave"",
                    ""type"": ""Button"",
                    ""id"": ""5f9681c3-c6d3-4c32-8bd0-2dc5b3b2081b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b2718597-161f-4aaa-8f59-4e63d7139edb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Placement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a73bb228-54d7-4a26-a9cc-7d4d32689732"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Interacting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a12ab3bd-f00d-4b97-93ab-d07b5e8319bc"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""RotatingR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aec6e4f3-7276-46dd-bb9f-4b0febcb98b8"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotatingL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa752c44-e6ff-48f9-9e92-1bafb20e1646"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartWave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard And Mouse"",
            ""bindingGroup"": ""Keyboard And Mouse"",
            ""devices"": []
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Walking = m_Movement.FindAction("Walking", throwIfNotFound: true);
        m_Movement_Escape = m_Movement.FindAction("Escape", throwIfNotFound: true);
        // Building
        m_Building = asset.FindActionMap("Building", throwIfNotFound: true);
        m_Building_Placement = m_Building.FindAction("Placement", throwIfNotFound: true);
        m_Building_Interacting = m_Building.FindAction("Interacting", throwIfNotFound: true);
        m_Building_RotatingR = m_Building.FindAction("RotatingR", throwIfNotFound: true);
        m_Building_RotatingL = m_Building.FindAction("RotatingL", throwIfNotFound: true);
        m_Building_StartWave = m_Building.FindAction("StartWave", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Walking;
    private readonly InputAction m_Movement_Escape;
    public struct MovementActions
    {
        private @NewControls m_Wrapper;
        public MovementActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walking => m_Wrapper.m_Movement_Walking;
        public InputAction @Escape => m_Wrapper.m_Movement_Escape;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Walking.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalking;
                @Walking.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalking;
                @Walking.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnWalking;
                @Escape.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walking.started += instance.OnWalking;
                @Walking.performed += instance.OnWalking;
                @Walking.canceled += instance.OnWalking;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Building
    private readonly InputActionMap m_Building;
    private IBuildingActions m_BuildingActionsCallbackInterface;
    private readonly InputAction m_Building_Placement;
    private readonly InputAction m_Building_Interacting;
    private readonly InputAction m_Building_RotatingR;
    private readonly InputAction m_Building_RotatingL;
    private readonly InputAction m_Building_StartWave;
    public struct BuildingActions
    {
        private @NewControls m_Wrapper;
        public BuildingActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Placement => m_Wrapper.m_Building_Placement;
        public InputAction @Interacting => m_Wrapper.m_Building_Interacting;
        public InputAction @RotatingR => m_Wrapper.m_Building_RotatingR;
        public InputAction @RotatingL => m_Wrapper.m_Building_RotatingL;
        public InputAction @StartWave => m_Wrapper.m_Building_StartWave;
        public InputActionMap Get() { return m_Wrapper.m_Building; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BuildingActions set) { return set.Get(); }
        public void SetCallbacks(IBuildingActions instance)
        {
            if (m_Wrapper.m_BuildingActionsCallbackInterface != null)
            {
                @Placement.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnPlacement;
                @Placement.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnPlacement;
                @Placement.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnPlacement;
                @Interacting.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnInteracting;
                @Interacting.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnInteracting;
                @Interacting.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnInteracting;
                @RotatingR.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnRotatingR;
                @RotatingR.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnRotatingR;
                @RotatingR.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnRotatingR;
                @RotatingL.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnRotatingL;
                @RotatingL.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnRotatingL;
                @RotatingL.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnRotatingL;
                @StartWave.started -= m_Wrapper.m_BuildingActionsCallbackInterface.OnStartWave;
                @StartWave.performed -= m_Wrapper.m_BuildingActionsCallbackInterface.OnStartWave;
                @StartWave.canceled -= m_Wrapper.m_BuildingActionsCallbackInterface.OnStartWave;
            }
            m_Wrapper.m_BuildingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Placement.started += instance.OnPlacement;
                @Placement.performed += instance.OnPlacement;
                @Placement.canceled += instance.OnPlacement;
                @Interacting.started += instance.OnInteracting;
                @Interacting.performed += instance.OnInteracting;
                @Interacting.canceled += instance.OnInteracting;
                @RotatingR.started += instance.OnRotatingR;
                @RotatingR.performed += instance.OnRotatingR;
                @RotatingR.canceled += instance.OnRotatingR;
                @RotatingL.started += instance.OnRotatingL;
                @RotatingL.performed += instance.OnRotatingL;
                @RotatingL.canceled += instance.OnRotatingL;
                @StartWave.started += instance.OnStartWave;
                @StartWave.performed += instance.OnStartWave;
                @StartWave.canceled += instance.OnStartWave;
            }
        }
    }
    public BuildingActions @Building => new BuildingActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard And Mouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnWalking(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
    public interface IBuildingActions
    {
        void OnPlacement(InputAction.CallbackContext context);
        void OnInteracting(InputAction.CallbackContext context);
        void OnRotatingR(InputAction.CallbackContext context);
        void OnRotatingL(InputAction.CallbackContext context);
        void OnStartWave(InputAction.CallbackContext context);
    }
}
