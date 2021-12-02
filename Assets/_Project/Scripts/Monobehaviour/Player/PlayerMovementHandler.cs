using UnityEngine;

public sealed class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField] private Transform _bodyJumper;
    private PlayerAnimationHandler _animatorHandler;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        GetReferences();
    }

    public void Move(float speed, Vector3 destination) // Called by PlayerController FixedUpdate | Change between lanes
    {
        if (!_animatorHandler.IsDead)
        {
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(transform.position, destination, step);
        }
    }

    public void Jump(float fallSpeed, float jumpHeight, float jumpSpeed) // Called by PlayerController FixedUpdate
    {
        if (_animatorHandler.IsJumping) // Move up
        {
            GravityUp(jumpHeight, jumpSpeed);
        }
        else // Not jumping, move down
        {
            GravityDown(fallSpeed);
        }
    }

    private void GetReferences()
    {
        _animatorHandler = this.GetComponent<PlayerAnimationHandler>();
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
            _animatorHandler.SetNotJumping();
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
}
