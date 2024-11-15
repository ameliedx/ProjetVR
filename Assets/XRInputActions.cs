//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.1
//     from Assets/XRInputActions.inputactions
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
using UnityEngine;

public partial class @XRInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @XRInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""XRInputActions"",
    ""maps"": [
        {
            ""name"": ""XRControls"",
            ""id"": ""7476be7a-61ac-424c-a1ad-bfdd7571b51d"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""6d157f50-7f7e-44f7-afb0-47a119593cfb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7330e764-0dc1-4056-bbe8-19dfad9166f0"",
                    ""path"": ""<OculusTouchController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // XRControls
        m_XRControls = asset.FindActionMap("XRControls", throwIfNotFound: true);
        m_XRControls_Shoot = m_XRControls.FindAction("Shoot", throwIfNotFound: true);
    }

    ~@XRInputActions()
    {
        Debug.Assert(!m_XRControls.enabled, "This will cause a leak and performance issues, XRInputActions.XRControls.Disable() has not been called.");
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

    // XRControls
    private readonly InputActionMap m_XRControls;
    private List<IXRControlsActions> m_XRControlsActionsCallbackInterfaces = new List<IXRControlsActions>();
    private readonly InputAction m_XRControls_Shoot;
    public struct XRControlsActions
    {
        private @XRInputActions m_Wrapper;
        public XRControlsActions(@XRInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_XRControls_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_XRControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(XRControlsActions set) { return set.Get(); }
        public void AddCallbacks(IXRControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_XRControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_XRControlsActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IXRControlsActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IXRControlsActions instance)
        {
            if (m_Wrapper.m_XRControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IXRControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_XRControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_XRControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public XRControlsActions @XRControls => new XRControlsActions(this);
    public interface IXRControlsActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
}
