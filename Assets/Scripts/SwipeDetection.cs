using System;
using System.Collections;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class SwipeDetection : MonoBehaviour
{
    public static SwipeDetection instance;

    [SerializeField] float minimumDistance = 0.2f;
    [SerializeField] float maximumTime = 1f;
    [SerializeField, Range(0,1)] float directionThreshold = 0.9f;

    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private float _startTime;
    private float _endTime;

    private void Awake()
    {
        instance = this.GetComponent<SwipeDetection>();
    }

    private void OnEnable()
    {
        InputManager.instance.OnStartTouch += SwipeStart;
        InputManager.instance.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        InputManager.instance.OnStartTouch -= SwipeStart;
        InputManager.instance.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        _startPosition = position;
        _startTime = time;
    }
    private void SwipeEnd(Vector2 position, float time)
    {
        _endPosition = position;
        _endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
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
            InputManager.instance.Jump();
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            InputManager.instance.MoveLeft();
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            InputManager.instance.MoveRight();
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            //Debug.Log("Swipe down");
        }
        else
        {
            //Debug.Log("Nothing");
        }
    }

}
