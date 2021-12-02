using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerHealthHandler _playerHealthHandler;
    [SerializeField] private BlockSpawner _blockSpawner;
    [SerializeField] private StatsSystem _statsSystem;
    [SerializeField] private CameraShaker _cameraShaker;
    [SerializeField] private LeadboardSystem _leadboardSystem;

    [SerializeField] private Button _touchToStartBtn;

    public Action OnReloadScene;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        UnsubscribeToEvents();
    }

    public void Init()
    {
        AddTouchButtonListener();
    }

    public void OnTouchToStart()
    {
        StartRunning();
    }

    public void StartRunning()
    {
        _blockSpawner.Init(); // start moving the scenary
        _playerController.StartRunning();
        _statsSystem.StartMeasuringDistance(); // start measuring the distance
        DisableTouchToStartScreen();
    }

    public void ReloadScene()
    {
        OnReloadScene?.Invoke();
    }

    private void SubscribeToEvents()
    {
        _playerHealthHandler.OnDeath += OnDeath;
    }

    private void UnsubscribeToEvents()
    {
        _playerHealthHandler.OnDeath -= OnDeath;
    }

    private void AddTouchButtonListener()
    {
        _touchToStartBtn.onClick.AddListener(OnTouchToStart);
    }

    private void DisableTouchToStartScreen()
    {
        _touchToStartBtn.gameObject.SetActive(false); // hide the 'touch to start' screen
    }

    private void OnDeath()
    {
        ShakeCamera();
        StopTheGame();
        SetLeadboardScreenOn();
    }

    private void StopTheGame()
    {
        _blockSpawner.StopAllBlocks();
        _statsSystem.StopMeasuringDistance();
    }

    private void ShakeCamera()
    {
        _cameraShaker.Shake(2, 5, 0.2f);
    }

    private void SetLeadboardScreenOn()
    {
        _leadboardSystem.ShowLeadboardScreen();
    }
}
