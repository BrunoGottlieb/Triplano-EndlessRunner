using UnityEngine;
using UnityEngine.UI;

public sealed class LaneSystem : MonoBehaviour
{
    public PlayerController player;
    public Transform[] lanes;

    private int _CurrentLaneIndex { get; set; } // Range 0 - 2
    private Transform _CurrentLane { get { return lanes[_CurrentLaneIndex]; } } // Current lane transform

    private void Awake()
    {
        _CurrentLaneIndex = 1; // Begins on the middle lane
    }

    private void OnEnable()
    {
        InputManager.Instance.OnMoveRight += DecreaseCurrentLane;
        InputManager.Instance.OnMoveLeft += IncreaseCurrentLane;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnMoveRight -= DecreaseCurrentLane;
        InputManager.Instance.OnMoveLeft -= IncreaseCurrentLane;
    }

    private void IncreaseCurrentLane() // Called on right input
    {
        if(_CurrentLaneIndex > 0 && player.CanChangeLane)
        {
            _CurrentLaneIndex--;
        }
    }

    private void DecreaseCurrentLane() // Called on left input
    {
        if (_CurrentLaneIndex < 2 && player.CanChangeLane)
        {
            _CurrentLaneIndex++;
        }
    }

    public Vector3 GetLane() // Called by player on Update Method
    {
        return _CurrentLane.position;
    }
}
