using UnityEngine;
using UnityEngine.UI;

public sealed class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block[] blocks;
    [SerializeField] private Button _touchToStartBtn;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float initialSpeed = 10;
    [SerializeField] private int _easyMediumDistance;
    [SerializeField] private int _mediumDistance;
    [SerializeField] private int _mediumHardDistance;
    [SerializeField] private int _hardDistance;
    private readonly float _spawnPos = -124;

    public float CurrentSpeed { get; set; }
    public float SpawnPos { get { return _spawnPos; } }
    public int EasyMediumDistance { get { return _easyMediumDistance; } }
    public int MediumDistance { get { return _mediumDistance; } }
    public int MediumHardDistance { get { return _mediumHardDistance; } }
    public int HardDistance { get { return _hardDistance; } }

    private static BlockSpawner _instance;
    public static BlockSpawner Instance { get { return _instance; } }

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        InitInstance();
        AddTouchButtonListener();
    }

    private void InitInstance()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogError("Not supposed to have more than 1 BlockSpawner on scene");
        }
        else
        {
            _instance = this;
        }
    }

    private void AddTouchButtonListener()
    {
        _touchToStartBtn.onClick.AddListener(OnTouchToStart);
    }

    private void DisableTouchToStartScreen()
    {
        _touchToStartBtn.gameObject.SetActive(false); // hide the 'touch to start' screen
    }

    public void OnTouchToStart()
    {
        CurrentSpeed = initialSpeed; // start moving the scenary
        _playerController.StartRunning();
        DisableTouchToStartScreen();
    }

    public void StopAllBlocks()
    {
        foreach(Block block in blocks)
        {
            block.IsEnabled = false;
        }
    }
}
