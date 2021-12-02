using UnityEngine;

public sealed class LaneSystem : MonoBehaviour
{
    [SerializeField] private Transform[] _lanes;
    private int _currentIndex = 1;
    private int _CurrentLaneIndex { get { return _currentIndex; } set { _currentIndex = value; } } // Range 0 - 2
    private int _LaneCount { get { return _lanes.Length; } } // Range 0 - 2
    private Transform _CurrentLane { get { return _lanes[_CurrentLaneIndex]; } } // Current lane transform

    public void IncreaseCurrentLane() // Called on player movement
    {
        _CurrentLaneIndex--;
    }

    public void DecreaseCurrentLane() // Called on player movement
    {
        _CurrentLaneIndex++;
    }

    public bool CanIncreaseLane()
    {
        return (_CurrentLaneIndex + 1) < _LaneCount;
    }

    public bool CanDecreaseLane()
    {
        return (_CurrentLaneIndex - 1) >= 0;
    }

    public Vector3 GetCurrentLane() // Called by player on Update Method
    {
        return _CurrentLane.position;
    }
}
