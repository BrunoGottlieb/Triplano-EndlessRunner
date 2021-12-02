using UnityEngine;

public sealed class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block[] _blocks;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _initialSpeed = 10;
    [SerializeField] private int _easyMediumDistance;
    [SerializeField] private int _mediumDistance;
    [SerializeField] private int _mediumHardDistance;
    [SerializeField] private int _hardDistance;
    private readonly float _spawnPos = -124;

    public float CurrentSpeed { get; private set; }
    public float SpawnPos { get { return _spawnPos; } }
    public int EasyMediumDistance { get { return _easyMediumDistance; } }
    public int MediumDistance { get { return _mediumDistance; } }
    public int MediumHardDistance { get { return _mediumHardDistance; } }
    public int HardDistance { get { return _hardDistance; } }

    public void Init()
    {
        CurrentSpeed = _initialSpeed;
    }

    public void StopAllBlocks()
    {
        foreach(Block block in _blocks)
        {
            block.IsEnabled = false;
        }
    }
}
