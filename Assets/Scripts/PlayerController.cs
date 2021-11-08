using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LaneSystem _laneSystem;
    [SerializeField] private int _laneSpeed = 8;
    [SerializeField] private float _jumpSpeed = 3;
    [SerializeField] private float _jumpHeight = 3;
    [SerializeField] private float _fallSpeed = 0.5f;

    private PlayerMovementManager _movementManager;

    private int _LaneSpeed { get; set; }
    private float _FallSpeed { get; set; }
    private float _JumpHeight { get; set; }
    private float _JumpSpeed { get; set; }
    public bool CanInteract { get; set; }
    public bool IsJumping { get; set; }

    private void Awake()
    {
        _movementManager = this.GetComponent<PlayerMovementManager>();
    }

    public void Init(int laneSpeed, float fallSpeed, float jumpSpeed, float jumpHeight, LaneSystem laneSystem)
    {
        _laneSystem = laneSystem;
        _laneSpeed = laneSpeed;
        _fallSpeed = fallSpeed;
        _jumpSpeed = jumpSpeed;
        _jumpHeight = jumpHeight;
        Start();
    }

    private void Start()
    {
        _LaneSpeed = _laneSpeed;
        _FallSpeed = _fallSpeed;
        _JumpSpeed = _jumpSpeed;
        _JumpHeight = _jumpHeight;
    }

    private void OnEnable()
    {
        InputManager.instance.OnMoveLeft += OnMoveLeft;
        InputManager.instance.OnMoveRight += OnMoveRight;
        InputManager.instance.OnJump += OnJump;
    }

    private void OnDisable()
    {
        InputManager.instance.OnMoveLeft -= OnMoveLeft;
        InputManager.instance.OnMoveRight -= OnMoveRight;
        InputManager.instance.OnJump -= OnJump;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Lane>() != null) // Player is on a lane
        {
            CanInteract = true;
        }
    }

    private void OnTriggerExit(Collider other) // Player can't interact while changing lane
    {
        CanInteract = false;
    }

    private void FixedUpdate()
    {
        _movementManager.Move(_LaneSpeed, _laneSystem.GetLane());
        _movementManager.Jump(_FallSpeed, _JumpHeight, _JumpSpeed);
    }

    private void OnMoveLeft() // Called by input event
    {

    }

    private void OnMoveRight() // Called by input event
    {

    }

    private void OnJump() // Called by input event
    {
        IsJumping = true;
    }
}
