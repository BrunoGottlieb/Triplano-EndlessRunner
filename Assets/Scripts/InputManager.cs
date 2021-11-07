using System;
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

    private PlayerControls playerControls;
    private Camera mainCamera;
    private void Awake()
    {
        instance = this.GetComponent<InputManager>();
        playerControls = new PlayerControls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        playerControls.Touch.PrimaryContact.started += context => StartTouchPrimary(context);
        playerControls.Touch.PrimaryContact.canceled += context => EndTouchPrimary(context);
        playerControls.Keyboard.LeftArrow.performed += context => MoveLeft();
        playerControls.Keyboard.RightArrow.performed += context => MoveRight();
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(Utils.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(Utils.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }

    public void MoveLeft() // Called by left command of all types of controllers
    {
        OnMoveLeft?.Invoke();
    }

    public void MoveRight() // Called by right command of all types of controllers
    {
        OnMoveRight?.Invoke();
    }

}
