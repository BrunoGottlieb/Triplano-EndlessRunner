using UnityEngine;

public sealed class PlayerMovementManager : MonoBehaviour
{
    [SerializeField] private Transform _bodyJumper;
    private PlayerController _playerController;
    private PlayerAnimationManager _animatorManager;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        _animatorManager = this.GetComponent<PlayerAnimationManager>();
        _playerController = this.GetComponent<PlayerController>();
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
        InputSystem.Instance.OnMoveLeft += MoveLeft;
        InputSystem.Instance.OnMoveRight += MoveRight;
        InputSystem.Instance.OnJump += Jump;
        InputSystem.Instance.OnSlide += Slide;
    }

    private void UnsubscribeToInputs()
    {
        InputSystem.Instance.OnMoveLeft -= MoveLeft;
        InputSystem.Instance.OnMoveRight -= MoveRight;
        InputSystem.Instance.OnJump -= Jump;
        InputSystem.Instance.OnSlide -= Slide;
    }

    private void MoveLeft() // Called by input action
    {
        _playerController.MoveLeft();
    }

    private void MoveRight() // Called by input action
    {
        _playerController.MoveRight();
    }

    private void Jump() // Called by input action
    {
        _playerController.Jump();
    }

    private void Slide() // Called by input action
    {
        _playerController.Slide();
    }

    private void GravityDown(float fallSpeed)
    {
        ApplyTransformMovement(fallSpeed, Vector3.zero);
    }

    private void GravityUp(float jumpHeight, float jumpSpeed)
    {
        ApplyTransformMovement(jumpSpeed, new Vector3(0, jumpHeight, 0));

        if (IsJumpOver(jumpHeight)) // Check maximum height
        {
            _playerController.StopJumping();
        }
    }

    private bool IsJumpOver(float jumpHeight)
    {
        return _bodyJumper.localPosition.y >= jumpHeight;
    }

    private void ApplyTransformMovement(float speed, Vector3 direction)
    {
        float step = speed * Time.deltaTime; // Gravity
        _bodyJumper.transform.localPosition = Vector3.MoveTowards(_bodyJumper.localPosition, direction, step);
    }

    public void Move(float speed, Vector3 destination) // Called by PlayerController FixedUpdate | Change between lanes
    {
        if (!_animatorManager.IsDead)
        {
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(transform.position, destination, step);
        }
    }

    public void Jump(float fallSpeed, float jumpHeight, float jumpSpeed) // Called by PlayerController FixedUpdate
    {
        if (_animatorManager.IsJumping) // Move up
        {
            GravityUp(jumpHeight, jumpSpeed);
        }
        else // Not jumping, move down
        {
            GravityDown(fallSpeed);
        }
    }
}
