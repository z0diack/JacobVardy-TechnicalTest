//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/CustomInput.inputactions
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

public partial class @CustomInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CustomInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CustomInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""c4e47334-fea6-4cfd-84de-4eaa6a49102d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""05212f65-b65d-4178-94ad-a6a48b5b3fc6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0a6e24fe-17bc-4df1-be27-ab3cfae40ac9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""5301a873-a5e1-4ce8-ba9a-e9899b40711a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spawn Menu"",
                    ""type"": ""Button"",
                    ""id"": ""8e0e1921-57d9-44cf-9251-6f838ceba31f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Main Menu"",
                    ""type"": ""Button"",
                    ""id"": ""8b8188d8-7490-4159-958d-231ff59e8aad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pickup"",
                    ""type"": ""Button"",
                    ""id"": ""07f606df-a121-4ea8-8937-4c01c795ad55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Delete"",
                    ""type"": ""Button"",
                    ""id"": ""1a8a3c25-2923-42b6-a844-5a7011bf30bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Edit"",
                    ""type"": ""Button"",
                    ""id"": ""a2d3b567-9e42-411c-b4f2-8a6d39bfae82"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spawn Cube"",
                    ""type"": ""Button"",
                    ""id"": ""816f677d-e197-4e36-a1ff-576e42cfb391"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spawn Sphere"",
                    ""type"": ""Button"",
                    ""id"": ""a81956cb-cdf0-4268-84ee-cb21ffff94c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spawn Cylinder"",
                    ""type"": ""Button"",
                    ""id"": ""f076aa35-765e-423c-8104-5680a7c0e162"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spawn Capsule"",
                    ""type"": ""Button"",
                    ""id"": ""d751fc97-334c-4f24-86a1-64c42786e208"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Copy"",
                    ""type"": ""Button"",
                    ""id"": ""fdf1e596-0508-43f9-bc19-41ce36e1258e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Paste"",
                    ""type"": ""Button"",
                    ""id"": ""f3c148f6-0570-4a5d-91b4-108c4a0683f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""3c948e1d-9c7e-4845-98bd-95b289c32203"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0ae557f7-e65a-4a94-a0fd-e5aa85c1c9a0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""512c94c0-d894-4905-b40b-2545f6478a98"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""753a46ff-b0f1-484f-bcb8-a518073ff2e3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e24da927-56ca-4aa2-abe6-1a470200b459"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5dce79c7-87fb-4079-b9de-fd0e7c0cbd8d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b9940e5-b335-447b-9f64-ce43f826c71e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a873691-5e75-4428-9abf-b05426eede46"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06ffc450-3ecb-4300-b14a-61ceee36f0ba"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Main Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37fb7c8e-9331-402c-a647-7bebbc5c8044"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac52ba84-b4ac-4a36-a74b-88f68af1932c"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Edit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e592d4dc-d9d5-4349-aa5f-65d7020c41b6"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b05baeca-da0b-41c2-a901-b7416d678154"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn Cube"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1e36b2e-5dbf-432c-b511-b386f0404b53"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn Sphere"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d5ea33d-38e6-46c9-bfba-39662ce12e3e"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn Cylinder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e89d749f-5a7d-4e8c-aae4-200c8bf76c77"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn Capsule"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fabc24b9-a38b-4ba2-9ddf-64b5794ab59b"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Copy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6a9e923-5380-4c01-aa32-a534bbf992b4"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Paste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        m_Player_SpawnMenu = m_Player.FindAction("Spawn Menu", throwIfNotFound: true);
        m_Player_MainMenu = m_Player.FindAction("Main Menu", throwIfNotFound: true);
        m_Player_Pickup = m_Player.FindAction("Pickup", throwIfNotFound: true);
        m_Player_Delete = m_Player.FindAction("Delete", throwIfNotFound: true);
        m_Player_Edit = m_Player.FindAction("Edit", throwIfNotFound: true);
        m_Player_SpawnCube = m_Player.FindAction("Spawn Cube", throwIfNotFound: true);
        m_Player_SpawnSphere = m_Player.FindAction("Spawn Sphere", throwIfNotFound: true);
        m_Player_SpawnCylinder = m_Player.FindAction("Spawn Cylinder", throwIfNotFound: true);
        m_Player_SpawnCapsule = m_Player.FindAction("Spawn Capsule", throwIfNotFound: true);
        m_Player_Copy = m_Player.FindAction("Copy", throwIfNotFound: true);
        m_Player_Paste = m_Player.FindAction("Paste", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Sprint;
    private readonly InputAction m_Player_SpawnMenu;
    private readonly InputAction m_Player_MainMenu;
    private readonly InputAction m_Player_Pickup;
    private readonly InputAction m_Player_Delete;
    private readonly InputAction m_Player_Edit;
    private readonly InputAction m_Player_SpawnCube;
    private readonly InputAction m_Player_SpawnSphere;
    private readonly InputAction m_Player_SpawnCylinder;
    private readonly InputAction m_Player_SpawnCapsule;
    private readonly InputAction m_Player_Copy;
    private readonly InputAction m_Player_Paste;
    public struct PlayerActions
    {
        private @CustomInput m_Wrapper;
        public PlayerActions(@CustomInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputAction @SpawnMenu => m_Wrapper.m_Player_SpawnMenu;
        public InputAction @MainMenu => m_Wrapper.m_Player_MainMenu;
        public InputAction @Pickup => m_Wrapper.m_Player_Pickup;
        public InputAction @Delete => m_Wrapper.m_Player_Delete;
        public InputAction @Edit => m_Wrapper.m_Player_Edit;
        public InputAction @SpawnCube => m_Wrapper.m_Player_SpawnCube;
        public InputAction @SpawnSphere => m_Wrapper.m_Player_SpawnSphere;
        public InputAction @SpawnCylinder => m_Wrapper.m_Player_SpawnCylinder;
        public InputAction @SpawnCapsule => m_Wrapper.m_Player_SpawnCapsule;
        public InputAction @Copy => m_Wrapper.m_Player_Copy;
        public InputAction @Paste => m_Wrapper.m_Player_Paste;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @SpawnMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnMenu;
                @SpawnMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnMenu;
                @SpawnMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnMenu;
                @MainMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMainMenu;
                @MainMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMainMenu;
                @MainMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMainMenu;
                @Pickup.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickup;
                @Pickup.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickup;
                @Pickup.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickup;
                @Delete.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDelete;
                @Delete.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDelete;
                @Delete.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDelete;
                @Edit.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEdit;
                @Edit.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEdit;
                @Edit.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEdit;
                @SpawnCube.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnCube;
                @SpawnCube.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnCube;
                @SpawnCube.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnCube;
                @SpawnSphere.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnSphere;
                @SpawnSphere.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnSphere;
                @SpawnSphere.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnSphere;
                @SpawnCylinder.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnCylinder;
                @SpawnCylinder.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnCylinder;
                @SpawnCylinder.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnCylinder;
                @SpawnCapsule.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnCapsule;
                @SpawnCapsule.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnCapsule;
                @SpawnCapsule.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnCapsule;
                @Copy.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCopy;
                @Copy.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCopy;
                @Copy.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCopy;
                @Paste.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPaste;
                @Paste.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPaste;
                @Paste.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPaste;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @SpawnMenu.started += instance.OnSpawnMenu;
                @SpawnMenu.performed += instance.OnSpawnMenu;
                @SpawnMenu.canceled += instance.OnSpawnMenu;
                @MainMenu.started += instance.OnMainMenu;
                @MainMenu.performed += instance.OnMainMenu;
                @MainMenu.canceled += instance.OnMainMenu;
                @Pickup.started += instance.OnPickup;
                @Pickup.performed += instance.OnPickup;
                @Pickup.canceled += instance.OnPickup;
                @Delete.started += instance.OnDelete;
                @Delete.performed += instance.OnDelete;
                @Delete.canceled += instance.OnDelete;
                @Edit.started += instance.OnEdit;
                @Edit.performed += instance.OnEdit;
                @Edit.canceled += instance.OnEdit;
                @SpawnCube.started += instance.OnSpawnCube;
                @SpawnCube.performed += instance.OnSpawnCube;
                @SpawnCube.canceled += instance.OnSpawnCube;
                @SpawnSphere.started += instance.OnSpawnSphere;
                @SpawnSphere.performed += instance.OnSpawnSphere;
                @SpawnSphere.canceled += instance.OnSpawnSphere;
                @SpawnCylinder.started += instance.OnSpawnCylinder;
                @SpawnCylinder.performed += instance.OnSpawnCylinder;
                @SpawnCylinder.canceled += instance.OnSpawnCylinder;
                @SpawnCapsule.started += instance.OnSpawnCapsule;
                @SpawnCapsule.performed += instance.OnSpawnCapsule;
                @SpawnCapsule.canceled += instance.OnSpawnCapsule;
                @Copy.started += instance.OnCopy;
                @Copy.performed += instance.OnCopy;
                @Copy.canceled += instance.OnCopy;
                @Paste.started += instance.OnPaste;
                @Paste.performed += instance.OnPaste;
                @Paste.canceled += instance.OnPaste;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnSpawnMenu(InputAction.CallbackContext context);
        void OnMainMenu(InputAction.CallbackContext context);
        void OnPickup(InputAction.CallbackContext context);
        void OnDelete(InputAction.CallbackContext context);
        void OnEdit(InputAction.CallbackContext context);
        void OnSpawnCube(InputAction.CallbackContext context);
        void OnSpawnSphere(InputAction.CallbackContext context);
        void OnSpawnCylinder(InputAction.CallbackContext context);
        void OnSpawnCapsule(InputAction.CallbackContext context);
        void OnCopy(InputAction.CallbackContext context);
        void OnPaste(InputAction.CallbackContext context);
    }
}