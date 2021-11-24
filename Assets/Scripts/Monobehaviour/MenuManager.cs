using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public sealed class MenuManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cam1;
    [SerializeField] private Transform _screen;
    [SerializeField] private SceneLoader _sceneLoader;

    [Header("Buttons")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        MoveCameraAndScreen();
        AddButtonListeners();
    }

    private void MoveCameraAndScreen()
    {
        _cam1.gameObject.SetActive(false);
        _screen.LeanMoveLocalY(0, 2).setEaseInOutBack();
    }

    private void AddButtonListeners()
    {
        _playButton.onClick.AddListener(HandlePlayButtonClick);
        _exitButton.onClick.AddListener(HandleQuitButtonClick);
    }

    private void HandlePlayButtonClick()
    {
        LoadGameScene();
    }

    private void HandleQuitButtonClick()
    {
        Quit();
    }

    private void LoadGameScene()
    {
        _sceneLoader.LoadScene("EndlessScene");
    }

    private void Quit()
    {
        Application.Quit();
    }
}
