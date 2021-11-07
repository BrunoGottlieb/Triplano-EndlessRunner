using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LaneSystem _laneSystem;
    [SerializeField] private int _speed = 8;

    private int Speed { get; set; }

    public void Init(int speed, LaneSystem laneSystem)
    {
        _laneSystem = laneSystem;
        _speed = speed;
        Start();
    }

    private void Start()
    {
        Speed = _speed;
    }

    private void OnEnable()
    {
        InputManager.instance.OnMoveLeft += OnMoveLeft;
        InputManager.instance.OnMoveRight += OnMoveRight;
    }

    private void OnDisable()
    {
        InputManager.instance.OnMoveLeft -= OnMoveLeft;
        InputManager.instance.OnMoveRight -= OnMoveRight;
    }

    private void FixedUpdate()
    {
        float step = Speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, _laneSystem.GetLane(), step);
    }

    private void OnMoveLeft()
    {

    }

    private void OnMoveRight()
    {

    }
}
