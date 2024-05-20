//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem/VehicleInput.inputactions
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

namespace Vehicle
{
    public partial class @VehicleInput: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @VehicleInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""VehicleInput"",
    ""maps"": [
        {
            ""name"": ""TemplateVehicle"",
            ""id"": ""cd56d55e-0b98-407f-84f4-17a1eb9b5ab1"",
            ""actions"": [
                {
                    ""name"": ""Acceleration"",
                    ""type"": ""Value"",
                    ""id"": ""f5af1169-0887-4ec6-9726-38cd6c0b093c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Steering"",
                    ""type"": ""Button"",
                    ""id"": ""d4c9090f-46a0-4ac6-8e7a-6065dd42f0f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HandBrake"",
                    ""type"": ""Button"",
                    ""id"": ""c74f7373-8f19-4d06-962a-764bdf0819ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""W/S"",
                    ""id"": ""0c8fed70-f348-4924-a1be-dab667c3d08d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""14421100-11a6-4ca8-ae7f-4df228a530c7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""07c34660-6f94-442f-8f94-d2969509c300"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""A/D"",
                    ""id"": ""e738294a-fbc8-4d02-bba3-2aaf16add129"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6a30de20-196a-449a-a38b-7a098ee10f1a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ccc3f9f0-2ed9-44d7-93c5-307b751932a9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2411e149-899c-4dc3-81e3-36f8e34b9050"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // TemplateVehicle
            m_TemplateVehicle = asset.FindActionMap("TemplateVehicle", throwIfNotFound: true);
            m_TemplateVehicle_Acceleration = m_TemplateVehicle.FindAction("Acceleration", throwIfNotFound: true);
            m_TemplateVehicle_Steering = m_TemplateVehicle.FindAction("Steering", throwIfNotFound: true);
            m_TemplateVehicle_HandBrake = m_TemplateVehicle.FindAction("HandBrake", throwIfNotFound: true);
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

        // TemplateVehicle
        private readonly InputActionMap m_TemplateVehicle;
        private List<ITemplateVehicleActions> m_TemplateVehicleActionsCallbackInterfaces = new List<ITemplateVehicleActions>();
        private readonly InputAction m_TemplateVehicle_Acceleration;
        private readonly InputAction m_TemplateVehicle_Steering;
        private readonly InputAction m_TemplateVehicle_HandBrake;
        public struct TemplateVehicleActions
        {
            private @VehicleInput m_Wrapper;
            public TemplateVehicleActions(@VehicleInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Acceleration => m_Wrapper.m_TemplateVehicle_Acceleration;
            public InputAction @Steering => m_Wrapper.m_TemplateVehicle_Steering;
            public InputAction @HandBrake => m_Wrapper.m_TemplateVehicle_HandBrake;
            public InputActionMap Get() { return m_Wrapper.m_TemplateVehicle; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TemplateVehicleActions set) { return set.Get(); }
            public void AddCallbacks(ITemplateVehicleActions instance)
            {
                if (instance == null || m_Wrapper.m_TemplateVehicleActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_TemplateVehicleActionsCallbackInterfaces.Add(instance);
                @Acceleration.started += instance.OnAcceleration;
                @Acceleration.performed += instance.OnAcceleration;
                @Acceleration.canceled += instance.OnAcceleration;
                @Steering.started += instance.OnSteering;
                @Steering.performed += instance.OnSteering;
                @Steering.canceled += instance.OnSteering;
                @HandBrake.started += instance.OnHandBrake;
                @HandBrake.performed += instance.OnHandBrake;
                @HandBrake.canceled += instance.OnHandBrake;
            }

            private void UnregisterCallbacks(ITemplateVehicleActions instance)
            {
                @Acceleration.started -= instance.OnAcceleration;
                @Acceleration.performed -= instance.OnAcceleration;
                @Acceleration.canceled -= instance.OnAcceleration;
                @Steering.started -= instance.OnSteering;
                @Steering.performed -= instance.OnSteering;
                @Steering.canceled -= instance.OnSteering;
                @HandBrake.started -= instance.OnHandBrake;
                @HandBrake.performed -= instance.OnHandBrake;
                @HandBrake.canceled -= instance.OnHandBrake;
            }

            public void RemoveCallbacks(ITemplateVehicleActions instance)
            {
                if (m_Wrapper.m_TemplateVehicleActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ITemplateVehicleActions instance)
            {
                foreach (var item in m_Wrapper.m_TemplateVehicleActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_TemplateVehicleActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public TemplateVehicleActions @TemplateVehicle => new TemplateVehicleActions(this);
        public interface ITemplateVehicleActions
        {
            void OnAcceleration(InputAction.CallbackContext context);
            void OnSteering(InputAction.CallbackContext context);
            void OnHandBrake(InputAction.CallbackContext context);
        }
    }
}
