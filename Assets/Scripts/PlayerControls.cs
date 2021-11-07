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
            ""name"": ""Touch"",
            ""id"": ""716afb82-3df7-43d2-9ea6-4c5b660d909f"",
            ""actions"": [
                {
                    ""name"": ""PrimaryContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""34144b27-4da1-447f-a951-cc487766ea97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PrimaryPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4e2a33d1-4abd-4f3b-876e-d912585283a3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3e5572a1-757f-4d17-b783-62180757c17f"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4424885d-7682-4205-8219-bccc504d2ece"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""id"": ""52ec1100-7088-4116-b47e-6966d25046fc"",
            ""actions"": [
                {
                    ""name"": ""LeftArrow"",
                    ""type"": ""Button"",
                    ""id"": ""3cc0e8f1-a4a6-44c5-b285-6ea61b9b7321"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightArrow"",
                    ""type"": ""Button"",
                    ""id"": ""72189b75-cc2c-4739-a127-e4d66d9116a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpArrow"",
                    ""type"": ""Button"",
                    ""id"": ""f781bfb0-db1b-48ce-929e-3b1835ab11b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DownArrow"",
                    ""type"": ""Button"",
                    ""id"": ""fbe9e7de-87b7-474e-994a-707ce7952aab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""72fe07b8-dc72-47ee-b21d-911213de0692"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f45bba64-65ab-4b35-a599-885c96d4177b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa490774-3e73-4ad6-a70f-2aa0fea3220e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17b09c85-e733-4f88-a8aa-8eed0cefe27d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df13abff-7679-4c21-90d4-c17f5068683d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dd0f181-488c-47e7-bac7-80d71964102f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f95fec6a-ea68-4185-9a42-aa6bc76a193c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97bbc78f-d5df-4d13-b1e1-a526db1bffd8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_PrimaryContact = m_Touch.FindAction("PrimaryContact", throwIfNotFound: true);
        m_Touch_PrimaryPosition = m_Touch.FindAction("PrimaryPosition", throwIfNotFound: true);
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_LeftArrow = m_Keyboard.FindAction("LeftArrow", throwIfNotFound: true);
        m_Keyboard_RightArrow = m_Keyboard.FindAction("RightArrow", throwIfNotFound: true);
        m_Keyboard_UpArrow = m_Keyboard.FindAction("UpArrow", throwIfNotFound: true);
        m_Keyboard_DownArrow = m_Keyboard.FindAction("DownArrow", throwIfNotFound: true);
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

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_PrimaryContact;
    private readonly InputAction m_Touch_PrimaryPosition;
    public struct TouchActions
    {
        private @PlayerControls m_Wrapper;
        public TouchActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryContact => m_Wrapper.m_Touch_PrimaryContact;
        public InputAction @PrimaryPosition => m_Wrapper.m_Touch_PrimaryPosition;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @PrimaryContact.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryContact;
                @PrimaryPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryPosition;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryContact.started += instance.OnPrimaryContact;
                @PrimaryContact.performed += instance.OnPrimaryContact;
                @PrimaryContact.canceled += instance.OnPrimaryContact;
                @PrimaryPosition.started += instance.OnPrimaryPosition;
                @PrimaryPosition.performed += instance.OnPrimaryPosition;
                @PrimaryPosition.canceled += instance.OnPrimaryPosition;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_LeftArrow;
    private readonly InputAction m_Keyboard_RightArrow;
    private readonly InputAction m_Keyboard_UpArrow;
    private readonly InputAction m_Keyboard_DownArrow;
    public struct KeyboardActions
    {
        private @PlayerControls m_Wrapper;
        public KeyboardActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftArrow => m_Wrapper.m_Keyboard_LeftArrow;
        public InputAction @RightArrow => m_Wrapper.m_Keyboard_RightArrow;
        public InputAction @UpArrow => m_Wrapper.m_Keyboard_UpArrow;
        public InputAction @DownArrow => m_Wrapper.m_Keyboard_DownArrow;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @LeftArrow.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLeftArrow;
                @LeftArrow.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLeftArrow;
                @LeftArrow.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLeftArrow;
                @RightArrow.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRightArrow;
                @RightArrow.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRightArrow;
                @RightArrow.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRightArrow;
                @UpArrow.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUpArrow;
                @UpArrow.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUpArrow;
                @UpArrow.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUpArrow;
                @DownArrow.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDownArrow;
                @DownArrow.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDownArrow;
                @DownArrow.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDownArrow;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftArrow.started += instance.OnLeftArrow;
                @LeftArrow.performed += instance.OnLeftArrow;
                @LeftArrow.canceled += instance.OnLeftArrow;
                @RightArrow.started += instance.OnRightArrow;
                @RightArrow.performed += instance.OnRightArrow;
                @RightArrow.canceled += instance.OnRightArrow;
                @UpArrow.started += instance.OnUpArrow;
                @UpArrow.performed += instance.OnUpArrow;
                @UpArrow.canceled += instance.OnUpArrow;
                @DownArrow.started += instance.OnDownArrow;
                @DownArrow.performed += instance.OnDownArrow;
                @DownArrow.canceled += instance.OnDownArrow;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface ITouchActions
    {
        void OnPrimaryContact(InputAction.CallbackContext context);
        void OnPrimaryPosition(InputAction.CallbackContext context);
    }
    public interface IKeyboardActions
    {
        void OnLeftArrow(InputAction.CallbackContext context);
        void OnRightArrow(InputAction.CallbackContext context);
        void OnUpArrow(InputAction.CallbackContext context);
        void OnDownArrow(InputAction.CallbackContext context);
    }
}
