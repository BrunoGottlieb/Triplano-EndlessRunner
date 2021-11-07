using UnityEngine;

public class LaneSystem : MonoBehaviour
{
    public Transform[] lanes;

    private int CurrentLaneIndex { get; set; } // Range 0 - 2
    private Transform CurrentLane { get { return lanes[CurrentLaneIndex]; } } // Current lane transform

    private void Awake()
    {
        CurrentLaneIndex = 1; // Begins on the middle lane
    }

    private void OnEnable()
    {
        SwipeDetection.instance.RightSwype += DecreaseCurrentLane;
        SwipeDetection.instance.LeftSwype += IncreaseCurrentLane;
    }

    private void OnDisable()
    {
        SwipeDetection.instance.RightSwype -= DecreaseCurrentLane;
        SwipeDetection.instance.LeftSwype -= IncreaseCurrentLane;
    }

    private void IncreaseCurrentLane() // Called on right swipe
    {
        if(CurrentLaneIndex > 0)
        {
            CurrentLaneIndex--;
        }
    }

    private void DecreaseCurrentLane() // Called on left swipe
    {
        if (CurrentLaneIndex < 2)
        {
            CurrentLaneIndex++;
        }
    }

    public Vector3 GetLane() // Called by player
    {
        return CurrentLane.position;
    }
}
