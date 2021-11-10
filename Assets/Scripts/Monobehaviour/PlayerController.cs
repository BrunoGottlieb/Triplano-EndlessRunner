using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField] private LaneSystem _laneSystem;
    [SerializeField] private int _laneSpeed = 8;
    [SerializeField] private float _jumpSpeed = 3;
    [SerializeField] private float _jumpHeight = 3;
    [SerializeField] private float _fallSpeed = 0.5f;
    [SerializeField] private GameObject[] bodyColliders; // 0 = stand | 1 = jump | 2 = slide

    private PlayerMovementManager _movementManager;
    private PlayerAnimationManager _animatorManager;
    private enum BodyCollider { Stand, Jump, Slide }

    private int _LaneSpeed { get; set; }
    private float _FallSpeed { get; set; }
    private float _JumpHeight { get; set; }
    private float _JumpSpeed { get; set; }
    public bool CanChangeLane { get; set; }

    private void Awake()
    {
        _movementManager = this.GetComponent<PlayerMovementManager>();
        _animatorManager = this.GetComponent<PlayerAnimationManager>();
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
        InputManager.Instance.OnMoveLeft += OnMoveLeft;
        InputManager.Instance.OnMoveRight += OnMoveRight;
        InputManager.Instance.OnJump += OnJump;
        InputManager.Instance.OnSlide += OnSlide;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnMoveLeft -= OnMoveLeft;
        InputManager.Instance.OnMoveRight -= OnMoveRight;
        InputManager.Instance.OnJump -= OnJump;
        InputManager.Instance.OnSlide -= OnSlide;
    }

    private void FixedUpdate()
    {
        if (!_animatorManager.IsJumping && !_animatorManager.IsSliding && _animatorManager.PlayerCanInteract)
        { 
            SetCollider((int)BodyCollider.Stand);
        }
        _movementManager.Move(_LaneSpeed, _laneSystem.GetLane());
        _movementManager.Jump(_FallSpeed, _JumpHeight, _JumpSpeed);
        _movementManager.Slide();
    }

    private void OnMoveLeft() // Called by input action
    {
        /// Not necessary
    }

    private void OnMoveRight() // Called by input action
    {
        /// Not necessary
    }

    private void OnJump() // Called by input action
    {
        if(_animatorManager.PlayerCanInteract)
        {
            SetCollider((int)BodyCollider.Jump);
        }
    }

    private void OnSlide() // Called by input action
    {
        if(_animatorManager.PlayerCanInteract)
        {
            SetCollider((int)BodyCollider.Slide);
        }
    }

    private void SetCollider(int value)
    {
        foreach (GameObject col in bodyColliders)
        {
            col.SetActive(false);
        }
        bodyColliders[value].SetActive(true);
    }

}
