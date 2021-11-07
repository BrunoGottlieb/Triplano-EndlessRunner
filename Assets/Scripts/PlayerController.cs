using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LaneSystem _laneSystem;
    [SerializeField] private int _speed = 8;

    private int Speed { get; set; }

    private Vector3 Destination { get; set; }

    public void Init(int speed, LaneSystem laneSystem)
    {
        _laneSystem = laneSystem;
        _speed = speed;
        Awake();
    }

    private void Awake()
    {
        Destination = _laneSystem.GetLane();
        Speed = _speed;
    }

    private void OnEnable()
    {
        SwipeDetection.instance.LeftSwype += MoveLeft;
        SwipeDetection.instance.RightSwype += MoveRight;
    }

    private void OnDisable()
    {
        SwipeDetection.instance.LeftSwype -= MoveLeft;
        SwipeDetection.instance.RightSwype -= MoveRight;
    }

    private void FixedUpdate()
    {
        float step = Speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, Destination, step);
    }

    private void MoveLeft()
    {
        Destination = _laneSystem.GetLane();
    }

    private void MoveRight()
    {
        Destination = _laneSystem.GetLane();
    }
}
