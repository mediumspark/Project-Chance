// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Basic"",
            ""id"": ""5bf563e3-ff5f-4188-b92f-158e9fbed0ed"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""63ce98bc-698d-4f8a-837a-9044b90fbbf2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""86df78e3-7dbd-4c1a-bc96-a7bc6df07998"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""24d4dabc-29ad-4f61-a692-d73c4e0bfabf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""72401a16-0b78-44c8-aa9e-3a94f196e701"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DamageSelf"",
                    ""type"": ""Button"",
                    ""id"": ""9ce71f83-c1ef-4e03-91cf-7927775e103b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6e852c16-f221-4649-96f6-c66452102d00"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e39ee11b-5744-427c-8d80-fb7933865457"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2055da57-995b-4372-aafc-1cce0fe31a63"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""07a45218-3071-4f2f-a5d9-3751da554acb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6260dcd5-4ccf-43cc-95ec-77cec088e52c"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f78d9886-6e42-45bf-b153-26f8b237a222"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""00f36ca2-4170-4f1c-8f51-655b24982851"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e41dbe33-06a0-4fcd-a70e-20ad767f79db"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bf8065d6-1277-42c8-906b-66c3f7f3251f"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fe07070a-cf7d-46bc-85d2-1a8f00bf6d72"",
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
                    ""id"": ""febe53f4-c3ec-438b-a63e-9be4ab327522"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6aeb148-24b7-4e5f-b639-afe3760e86e5"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f3edfbf-91c8-4e4d-b344-736106c0840f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc2ba34f-847c-42e5-abe5-8b73e59e307d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4d673c2-daac-45cf-bef8-a6195b3d086a"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0d4e17a-66ba-466d-8331-6c0426329af6"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DamageSelf"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Basic
        m_Basic = asset.FindActionMap("Basic", throwIfNotFound: true);
        m_Basic_Movement = m_Basic.FindAction("Movement", throwIfNotFound: true);
        m_Basic_Jump = m_Basic.FindAction("Jump", throwIfNotFound: true);
        m_Basic_Crouch = m_Basic.FindAction("Crouch", throwIfNotFound: true);
        m_Basic_Attack = m_Basic.FindAction("Attack", throwIfNotFound: true);
        m_Basic_DamageSelf = m_Basic.FindAction("DamageSelf", throwIfNotFound: true);
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

    // Basic
    private readonly InputActionMap m_Basic;
    private IBasicActions m_BasicActionsCallbackInterface;
    private readonly InputAction m_Basic_Movement;
    private readonly InputAction m_Basic_Jump;
    private readonly InputAction m_Basic_Crouch;
    private readonly InputAction m_Basic_Attack;
    private readonly InputAction m_Basic_DamageSelf;
    public struct BasicActions
    {
        private @PlayerControls m_Wrapper;
        public BasicActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Basic_Movement;
        public InputAction @Jump => m_Wrapper.m_Basic_Jump;
        public InputAction @Crouch => m_Wrapper.m_Basic_Crouch;
        public InputAction @Attack => m_Wrapper.m_Basic_Attack;
        public InputAction @DamageSelf => m_Wrapper.m_Basic_DamageSelf;
        public InputActionMap Get() { return m_Wrapper.m_Basic; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicActions set) { return set.Get(); }
        public void SetCallbacks(IBasicActions instance)
        {
            if (m_Wrapper.m_BasicActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnCrouch;
                @Attack.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnAttack;
                @DamageSelf.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnDamageSelf;
                @DamageSelf.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnDamageSelf;
                @DamageSelf.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnDamageSelf;
            }
            m_Wrapper.m_BasicActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @DamageSelf.started += instance.OnDamageSelf;
                @DamageSelf.performed += instance.OnDamageSelf;
                @DamageSelf.canceled += instance.OnDamageSelf;
            }
        }
    }
    public BasicActions @Basic => new BasicActions(this);
    public interface IBasicActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDamageSelf(InputAction.CallbackContext context);
    }
}
