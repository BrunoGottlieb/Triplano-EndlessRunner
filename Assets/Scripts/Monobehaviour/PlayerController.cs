using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject[] _bodyColliders; // 0 = stand | 1 = jump | 2 = slide
    [SerializeField] private LaneSystem _laneSystem;
    [SerializeField] private LeadboardScreen _leadboardScreen;
    [SerializeField] private int _laneSpeed = 8;
    [SerializeField] private float _jumpSpeed = 3;
    [SerializeField] private float _jumpHeight = 3;
    [SerializeField] private float _fallSpeed = 0.5f;

    private PlayerMovementManager _movementManager;
    private PlayerAnimationManager _animatorManager;
    private PlayerSoundManager _soundManager;

    private enum BodyCollider { Stand, Jump, Slide }

    private int _LaneSpeed { get; set; }
    private float _FallSpeed { get; set; }
    private float _JumpHeight { get; set; }
    private float _JumpSpeed { get; set; }

    private void Awake()
    {
        GetReferences();
    }
    private void GetReferences()
    {
        _movementManager = this.GetComponent<PlayerMovementManager>();
        _animatorManager = this.GetComponent<PlayerAnimationManager>();
        _soundManager = this.GetComponent<PlayerSoundManager>();
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

    private void Start()
    {
        SetVariableValues();
    }

    private void SetVariableValues()
    {
        _LaneSpeed = _laneSpeed;
        _FallSpeed = _fallSpeed;
        _JumpSpeed = _jumpSpeed;
        _JumpHeight = _jumpHeight;
    }

    private void FixedUpdate()
    {
        DoMovement();
    }

    private void DoMovement()
    {
        SetStandCollider();
        _movementManager.Move(_LaneSpeed, _laneSystem.GetCurrentLane());
        _movementManager.Jump(_FallSpeed, _JumpHeight, _JumpSpeed);
    }

    private void SetStandCollider()
    {
        if (_animatorManager.IsStanding)
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

    private void TakeDamage() // Called when collided with something but not died (life > 0)
    {
        _animatorManager.PlayDamageAnimation();
    }

    private void Die() // Called when collided with something and life is now zero
    {
        if(_animatorManager.IsDead) { return; }
        _animatorManager.PlayDeathAnimation();
        ShakeCamera();
        StopTheGame();
        SetLeadboardScreenOn();
    }

    private void StopTheGame()
    {
        BlockSpawner.Instance.StopAllBlocks();
        StatsSystem.Instance.StopMeasuringDistance();
    }

    private void ShakeCamera()
    {
        CameraShaker.Instance.Shake(2, 5, 0.2f);
    }

    private void SetLeadboardScreenOn()
    {
        _leadboardScreen.gameObject.SetActive(true);
    }

    private int CalculateDamage(int damageQtd)
    {
        int currentEnergy = StatsSystem.Instance.Energy;
        return currentEnergy - damageQtd;
    }

    private void SetDamageOnPlayerStats(int damageValue) // When taking damage
    {
        StatsSystem.Instance.ApplyDamage(damageValue);
    }

    public void StartRunning()
    {
        _animatorManager.StartRunning(); // start player run animation
        StatsSystem.Instance.StartMeasuringDistance(); // start measuring the distance
    }

    public void MoveLeft() // Called by input action
    {
        if (_laneSystem.CanDecreaseLane())
        {
            _laneSystem.IncreaseCurrentLane();
            _soundManager.PlayAirSound();
        }
    }

    public void MoveRight() // Called by input action
    {
        if (_laneSystem.CanIncreaseLane())
        {
            _laneSystem.DecreaseCurrentLane();
            _soundManager.PlayAirSound();
        }
    }

    public void Slide() // Called by input action
    {
        if (_animatorManager.PlayerCanInteract)
        {
            SetCollider(BodyCollider.Slide);
            _soundManager.PlaySlideSound();
            _animatorManager.PlaySlideAnimation();
        }
    }

    public void Jump() // Called by input action
    {
        if (_animatorManager.PlayerCanInteract)
        {
            SetCollider(BodyCollider.Jump);
            _soundManager.PlayJumpSound();
            _animatorManager.PlayJumpAnimation();
        }
    }

    public void StopJumping()
    {
        _animatorManager.SetNotJumping(); // Not jumping anymore
    }

    public void ReceiveDamage(int damageQtd) // Called by PlayerInteraction when collided with something
    {
        int remainingLife = CalculateDamage(damageQtd);
        if (remainingLife > 0)
        {
            TakeDamage();
        }
        else
        {
            Die();
        }
        SetDamageOnPlayerStats(damageQtd);
    }
}
