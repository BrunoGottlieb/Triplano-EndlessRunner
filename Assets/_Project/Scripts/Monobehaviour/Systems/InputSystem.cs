using System;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public sealed class InputSystem : MonoBehaviour
{
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
        Init();
    }

    private void Start()
    {
        SubscribeOnInputs();
    }

    private void OnEnable()
    {
        EnablePlayerControls();
    }

    private void OnDisable()
    {
        DisablePlayerControls();
    }

    public void Init()
    {
        _playerControls = new PlayerControls();
    }

    public void SubscribeOnInputs()
    {
        _playerControls.Touch.PrimaryContact.started += context => StartTouchPrimary(context);
        _playerControls.Touch.PrimaryContact.canceled += context => EndTouchPrimary(context);
        _playerControls.Touch.CurrentPosition.performed += context => CurrentTouchPosition(context);

        _playerControls.Keyboard.LeftArrow.performed += context => MoveLeft();
        _playerControls.Keyboard.RightArrow.performed += context => MoveRight();
        _playerControls.Keyboard.UpArrow.performed += context => Jump();
        _playerControls.Keyboard.DownArrow.performed += context => Slide();
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

    private void EnablePlayerControls()
    {
        _playerControls.Enable();
    }

    private void DisablePlayerControls()
    {
        _playerControls.Disable();
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
}
