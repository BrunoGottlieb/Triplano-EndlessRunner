using UnityEngine;

public sealed class Block : MonoBehaviour
{
    [SerializeField] private BlockSpawner _spawner;
    [SerializeField] private GameObject _debugStage;
    [SerializeField] private GameObject[] _easyGroup;
    [SerializeField] private GameObject[] _mediumGroup;
    [SerializeField] private GameObject[] _hardGroup;
    private readonly float _deathValue = 110.3f;

    public bool IsEnabled { get; set; }
    private GameObject _CurrentStage { get; set; }

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        IsEnabled = true;
        ChooseContent();
    }

    private void FixedUpdate()
    {
        MoveTheBlock();
    }

    private void MoveTheBlock() // if player is alive, keep moving the block
    {
        if (!IsEnabled) { return; }

        this.transform.Translate(_spawner.CurrentSpeed * Time.deltaTime * Vector3.right, Space.Self);

        if (IsRespawnPosition())
        {
            ResetPosition();
            ChooseContent();
        }
    }

    private bool IsRespawnPosition()
    {
        return this.transform.localPosition.x >= _deathValue;
    }

    private void ResetPosition()
    {
        this.transform.localPosition = new Vector3(_spawner.SpawnPos, 0, 0);
    }

    private void ChooseContent() // random choose a group of obstacles and collectables
    {
        int distance = StatsSystem.Instance != null ? StatsSystem.Instance.Distance : 0; // current distance travelled by player
        _CurrentStage?.SetActive(false); // disable (now)previous stage

        if (IsEasyDistance(distance)) // will spawn an easy stage
        {
            _CurrentStage = GetRandomStage(_easyGroup);
        }
        else if (IsEasyMediumDistance(distance)) // will easy stages and medium stages
        {
            _CurrentStage = GetRandomStage(_easyGroup, _mediumGroup);
        }
        else if (IsMediumDistance(distance)) // will spawn a medium stage
        {
            _CurrentStage = GetRandomStage(_mediumGroup);
        }
        else if (IsMediumHardDistance(distance)) // will spawn medium stages and hard stages
        {
            _CurrentStage = GetRandomStage(_mediumGroup, _hardGroup);
        }
        else if (IsHardDistance(distance)) // will spawn only hard stages
        {
            _CurrentStage = GetRandomStage(_hardGroup);
        }
        else
        {
            Debug.LogError("Something went wrong on block difficult chooser");
        }

        if (_debugStage != null) // only for tests porpouse
        {
            _CurrentStage = _debugStage;
        }

        _CurrentStage.SetActive(true);
    }

    private GameObject GetRandomStage(GameObject[] groupA, GameObject[] groupB = null)
    {
        int sizeA = groupA.Length;
        int sizeB = groupB != null ? groupB.Length : 0;
        int rand = Random.Range(0, sizeA + sizeB);

        if (groupA.Length > rand)
        {
            return groupA[rand];
        }
        else
        {
            return groupB[rand - sizeA];
        }
    }

    private bool IsEasyDistance(float distance)
    {
        return distance < _spawner.EasyMediumDistance;
    }

    private bool IsEasyMediumDistance(int distance)
    {
        return distance >= _spawner.EasyMediumDistance && distance < _spawner.MediumDistance;
    }

    private bool IsMediumDistance(int distance)
    {
        return distance >= _spawner.MediumDistance && distance < _spawner.MediumHardDistance;
    }

    private bool IsMediumHardDistance(int distance)
    {
        return distance >= _spawner.MediumDistance && distance < _spawner.HardDistance;
    }

    private bool IsHardDistance(int distance)
    {
        return distance >= _spawner.HardDistance;
    }

}
