using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;
using System.Collections;

public sealed class MenuManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cam1;
    [SerializeField] private Transform _screen;

    [Header("Buttons")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;

    [Header("Loading")]
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _loadingSlider;

    private void Start()
    {
        _cam1.gameObject.SetActive(false);
        _screen.LeanMoveLocalY(0, 2).setEaseInOutBack();
        _playButton.onClick.AddListener(HandlePlayButtonClick);
        _exitButton.onClick.AddListener(HandleQuitButtonClick);
        _loadingScreen.SetActive(false);
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
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync("EndlessScene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            print(progress);
            _loadingSlider.value = progress;
            yield return null;
        }

    }

    private void Quit()
    {
        Application.Quit();
    }
}
