using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject[] _bodyColliders; // 0 = stand | 1 = jump | 2 = slide
    [SerializeField] private LaneSystem _laneSystem;
    [SerializeField] private int _laneSpeed = 8;
    [SerializeField] private float _jumpSpeed = 3;
    [SerializeField] private float _jumpHeight = 3;
    [SerializeField] private float _fallSpeed = 0.5f;

    [SerializeField] private InputSystem _inputSystem;
    private PlayerMovementHandler _movementHandler;
    private PlayerAnimationHandler _animatorHandler;
    private PlayerSoundHandler _soundHandler;

    private enum BodyCollider { Stand, Jump, Slide }

    private int _LaneSpeed { get; set; }
    private float _FallSpeed { get; set; }
    private float _JumpHeight { get; set; }
    private float _JumpSpeed { get; set; }

    private void Awake()
    {
        GetReferences();
    }

    private void Start()
    {
        SetVariableValues();
    }

    public void Init(int laneSpeed, float fallSpeed, float jumpSpeed, float jumpHeight, LaneSystem laneSystem)
    {
        _laneSystem = laneSystem;
        _laneSpeed = laneSpeed;
        _fallSpeed = fallSpeed;
        _jumpSpeed = jumpSpeed;
        _jumpHeight = jumpHeight;
        GetReferences();
        SetVariableValues();
    }

    public void StartRunning()
    {
        _animatorHandler.StartRunning(); // start player run animation
    }

    private void GetReferences()
    {
        _movementHandler = this.GetComponent<PlayerMovementHandler>();
        _animatorHandler = this.GetComponent<PlayerAnimationHandler>();
        _soundHandler = this.GetComponent<PlayerSoundHandler>();
    }

    private void SetVariableValues()
    {
        _LaneSpeed = _laneSpeed;
        _FallSpeed = _fallSpeed;
        _JumpSpeed = _jumpSpeed;
        _JumpHeight = _jumpHeight;
    }

    private void OnEnable()
    {
        SubscribeToInputs();
    }

    private void OnDisable()
    {
        UnsubscribeToInputs();
    }

    private void SubscribeToInputs()
    {
        _inputSystem.OnMoveLeft += MoveLeft;
        _inputSystem.OnMoveRight += MoveRight;
        _inputSystem.OnJump += Jump;
        _inputSystem.OnSlide += Slide;
    }

    private void UnsubscribeToInputs()
    {
        _inputSystem.OnMoveLeft -= MoveLeft;
        _inputSystem.OnMoveRight -= MoveRight;
        _inputSystem.OnJump -= Jump;
        _inputSystem.OnSlide -= Slide;
    }

    private void FixedUpdate()
    {
        DoMovement();
    }

    private void DoMovement()
    {
        SetStandCollider();
        _movementHandler.Move(_LaneSpeed, _laneSystem.GetCurrentLane());
        _movementHandler.Jump(_FallSpeed, _JumpHeight, _JumpSpeed);
    }

    private void SetStandCollider()
    {
        if (_animatorHandler.IsStanding)
        {
            SetCollider(BodyCollider.Stand);
        }
    }

    private void SetCollider(BodyCollider collider) // On jump or slide
    {
        foreach (GameObject col in _bodyColliders)
        {
            col.SetActive(false);
        }
        _bodyColliders[(int)collider].SetActive(true);
    }

    private void MoveLeft() // Called by input action
    {
        if (_laneSystem.CanDecreaseLane())
        {
            _laneSystem.IncreaseCurrentLane();
            _soundHandler.PlayAirSound();
        }
    }

    private void MoveRight() // Called by input action
    {
        if (_laneSystem.CanIncreaseLane())
        {
            _laneSystem.DecreaseCurrentLane();
            _soundHandler.PlayAirSound();
        }
    }

    private void Slide() // Called by input action
    {
        if (_animatorHandler.PlayerCanInteract)
        {
            SetCollider(BodyCollider.Slide);
            _soundHandler.PlaySlideSound();
            _animatorHandler.PlaySlideAnimation();
        }
    }

    private void Jump() // Called by input action
    {
        if (_animatorHandler.PlayerCanInteract)
        {
            SetCollider(BodyCollider.Jump);
            _soundHandler.PlayJumpSound();
            _animatorHandler.PlayJumpAnimation();
        }
    }
}
