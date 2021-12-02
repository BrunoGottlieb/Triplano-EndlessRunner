using UnityEngine;

public sealed class SwipeDetection : MonoBehaviour
{
    [SerializeField] InputSystem _inputSystem;
    [SerializeField] float _minimumDistance = 0.2f;
    [SerializeField] float _maximumTime = 1f;
    [SerializeField, Range(0,1)] float _directionThreshold = 0.9f;

    private Vector2 _startPosition;
    private Vector2 _currentPosition;
    private float _startTime;
    private float _endTime;

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
        _inputSystem.OnStartTouch += SwipeStart;
        _inputSystem.OnEndTouch += SwipeEnd;
        _inputSystem.OnCurrentTouch += UpdateTouchPosition;
    }

    private void UnsubscribeToInputs()
    {
        _inputSystem.OnStartTouch -= SwipeStart;
        _inputSystem.OnEndTouch -= SwipeEnd;
        _inputSystem.OnCurrentTouch -= UpdateTouchPosition;
    }

    private void SwipeStart(Vector2 position, float time) // Start touching the screen
    {
        _startPosition = position;
        _startTime = time;
    }
    private void SwipeEnd(Vector2 position, float time) // Not touching it anymore
    {
        /// Not using it anymore
    }

    private void UpdateTouchPosition(Vector2 position, float time) // Called whiel touching the screen
    {
        _currentPosition = position;
        _endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (IsIndeedSwipe())
        {
            Vector3 direction = _currentPosition - _startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
            _startTime = -Mathf.Infinity;
        }
    }

    private bool IsIndeedSwipe() // Check if it's indeed a swype
    {
        return Vector2.Distance(_startPosition, _currentPosition) >= _minimumDistance &&
            (_endTime - _startTime) <= _maximumTime;
    }

    private void SwipeDirection(Vector2 direction)
    {
        if(Vector2.Dot(Vector2.up, direction) > _directionThreshold)
        {
            _inputSystem.Jump();
        }
        else if (Vector2.Dot(Vector2.left, direction) > _directionThreshold)
        {
            _inputSystem.MoveLeft();
        }
        else if (Vector2.Dot(Vector2.right, direction) > _directionThreshold)
        {
            _inputSystem.MoveRight();
        }
        else if (Vector2.Dot(Vector2.down, direction) > _directionThreshold)
        {
            _inputSystem.Slide();
        }
        else
        {
            Debug.Log("Nothing");
        }
    }
}
