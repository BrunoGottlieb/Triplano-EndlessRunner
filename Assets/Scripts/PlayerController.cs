using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LaneSystem _laneSystem;
    [SerializeField] private int _speed = 8;
    [SerializeField] private float _jumpSpeed = 3;
    [SerializeField] private float _fallMultiplier = 0.5f;

    private PlayerMovementManager _movementManager;
    private Rigidbody _rb;

    private int _Speed { get; set; }
    private float _FallMultiplier { get; set; }
    private float _JumpSpeed { get; set; }
    public bool CanInteract { get; set; }

    private void Awake()
    {
        _movementManager = this.GetComponent<PlayerMovementManager>();
        _rb = this.GetComponent<Rigidbody>();
    }

    public void Init(int speed, float fallMultiplier, float jumpSpeed, LaneSystem laneSystem)
    {
        _laneSystem = laneSystem;
        _speed = speed;
        _fallMultiplier = fallMultiplier;
        _jumpSpeed = jumpSpeed;
        Start();
    }

    private void Start()
    {
        _Speed = _speed;
        _FallMultiplier = _fallMultiplier;
        _JumpSpeed = _jumpSpeed;
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
        _movementManager.Move(_Speed, _laneSystem.GetLane());
        _movementManager.Jump(_rb, _FallMultiplier);
    }

    private void OnMoveLeft()
    {

    }

    private void OnMoveRight()
    {

    }

    private void OnJump()
    {
        _movementManager.ApplyJump(_rb, _jumpSpeed);
    }
}
