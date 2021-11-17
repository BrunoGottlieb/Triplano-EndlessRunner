using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public sealed class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }

    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    public delegate void CurrentTouch(Vector2 position, float time);
    public event CurrentTouch OnCurrentTouch;

    public Action OnMoveLeft;
    public Action OnMoveRight;
    public Action OnJump;
    public Action OnSlide;

    private PlayerControls _playerControls;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogError("Not supposed to have more than 1 InputManager on scene");
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void Start()
    {
        _playerControls.Touch.PrimaryContact.started += context => StartTouchPrimary(context);
        _playerControls.Touch.PrimaryContact.canceled += context => EndTouchPrimary(context);
        _playerControls.Touch.CurrentPosition.performed += context => CurrentTouchPosition(context);

        _playerControls.Keyboard.LeftArrow.performed += context => MoveLeft();
        _playerControls.Keyboard.RightArrow.performed += context => MoveRight();
        _playerControls.Keyboard.UpArrow.performed += context => Jump();
        _playerControls.Keyboard.DownArrow.performed += context => Slide();
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(_playerControls.Touch.PrimaryPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(_playerControls.Touch.PrimaryPosition.ReadValue<Vector2>(), (float)context.time);
    }

    private void CurrentTouchPosition(InputAction.CallbackContext context)
    {
        OnCurrentTouch?.Invoke(_playerControls.Touch.CurrentPosition.ReadValue<Vector2>(), (float)context.time);
    }

    public void MoveLeft()
    {
        OnMoveLeft?.Invoke();
    }

    public void MoveRight()
    {
        OnMoveRight?.Invoke();
    }
    public void Jump()
    {
        OnJump?.Invoke();
    }
    public void Slide()
    {
        OnSlide?.Invoke();
    }
}
