using UnityEngine;
using UnityEngine.UI;

public class LaneSystem : MonoBehaviour
{
    public Text currentLaneText;
    public Transform[] lanes;

    private int CurrentLaneIndex { get; set; } // Range 0 - 2
    private Transform CurrentLane { get { return lanes[CurrentLaneIndex]; } } // Current lane transform

    private void Awake()
    {
        CurrentLaneIndex = 1; // Begins on the middle lane
    }

    private void Update()
    {
        currentLaneText.text = CurrentLaneIndex.ToString();
    }

    private void OnEnable()
    {
        InputManager.instance.OnMoveRight += DecreaseCurrentLane;
        InputManager.instance.OnMoveLeft += IncreaseCurrentLane;
    }

    private void OnDisable()
    {
        InputManager.instance.OnMoveRight -= DecreaseCurrentLane;
        InputManager.instance.OnMoveLeft -= IncreaseCurrentLane;
    }

    private void IncreaseCurrentLane() // Called on right input
    {
        if(CurrentLaneIndex > 0)
        {
            CurrentLaneIndex--;
        }
    }

    private void DecreaseCurrentLane() // Called on left input
    {
        if (CurrentLaneIndex < 2)
        {
            CurrentLaneIndex++;
        }
    }

    public Vector3 GetLane() // Called by player on Update Method
    {
        return CurrentLane.position;
    }
}
