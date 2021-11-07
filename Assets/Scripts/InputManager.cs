using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;

    public Action OnMoveLeft;
    public Action OnMoveRight;
    public Action OnJump;

    private PlayerControls _playerControls;
    private Camera _mainCamera;
    private void Awake()
    {
        instance = this.GetComponent<InputManager>();
        _playerControls = new PlayerControls();
        _mainCamera = Camera.main;
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

        _playerControls.Keyboard.LeftArrow.performed += context => MoveLeft();
        _playerControls.Keyboard.RightArrow.performed += context => MoveRight();
        _playerControls.Keyboard.UpArrow.performed += context => Jump();
        _playerControls.Keyboard.DownArrow.performed += context => Crouch();
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(Utils.ScreenToWorld(_mainCamera, _playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(Utils.ScreenToWorld(_mainCamera, _playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }

    public void MoveLeft() // Called by left command of all types of controllers
    {
        OnMoveLeft?.Invoke();
    }

    public void MoveRight() // Called by right command of all types of controllers
    {
        OnMoveRight?.Invoke();
    }
    internal void Jump()
    {
        OnJump?.Invoke();
    }
    private void Crouch()
    {
        throw new NotImplementedException();
    }
}
