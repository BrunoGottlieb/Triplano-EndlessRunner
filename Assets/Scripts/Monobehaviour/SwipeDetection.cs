using System;
using System.Collections;
using UnityEngine;

public sealed class SwipeDetection : MonoBehaviour
{
    [SerializeField] float minimumDistance = 0.2f;
    [SerializeField] float maximumTime = 1f;
    [SerializeField, Range(0,1)] float directionThreshold = 0.9f;

    private Vector2 _startPosition;
    private Vector2 _currentPosition;
    private Vector2 _endPosition;
    private float _startTime;
    private float _endTime;

    private void OnEnable()
    {
        InputManager.Instance.OnStartTouch += SwipeStart;
        InputManager.Instance.OnEndTouch += SwipeEnd;
        InputManager.Instance.OnCurrentTouch += UpdateTouchPosition;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnStartTouch -= SwipeStart;
        InputManager.Instance.OnEndTouch -= SwipeEnd;
        InputManager.Instance.OnCurrentTouch -= UpdateTouchPosition;
    }

    private void SwipeStart(Vector2 position, float time) // Start touching the screen
    {
        _startPosition = position;
        _startTime = time;
    }
    private void SwipeEnd(Vector2 position, float time) // Not touching it anymore
    {
        /*_endPosition = position;
        _endTime = time;
        DetectFinalSwipe();*/
    }

    private void UpdateTouchPosition(Vector2 position, float time)
    {
        _currentPosition = position;
        _endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe() // Check if it's indeed a swype
    {
        if (Vector3.Distance(_startPosition, _currentPosition) >= minimumDistance && 
            (_endTime - _startTime) <= maximumTime)
        {
            Vector3 direction = _currentPosition - _startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
            _startTime = -Mathf.Infinity;
        }
    }

    private void DetectFinalSwipe() // Check if it's indeed a swype
    {
        if (Vector3.Distance(_startPosition, _endPosition) >= minimumDistance &&
            (_endTime - _startTime) <= maximumTime)
        {
            Debug.DrawLine(_startPosition, _endPosition, Color.red, 5);
            Vector3 direction = _endPosition - _startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if(Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            InputManager.Instance.Jump();
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            InputManager.Instance.MoveLeft();
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            InputManager.Instance.MoveRight();
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            InputManager.Instance.Slide();
        }
        else
        {
            //Debug.Log("Nothing");
        }
    }

}
