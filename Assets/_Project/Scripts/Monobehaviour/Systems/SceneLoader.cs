using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _loadingScreen;

    private void Start()
    {
        EnableLoadingScreen();
    }

    private void OnEnable()
    {
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        UnsubscribeToEvents();
    }

    public void ReloadScene()
    {
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().name));
    }

    public void LoadScene(string sceneName)
    {
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    public void LoadScene(int sceneIndex)
    {
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(SceneManager.GetSceneAt(sceneIndex).name));
    }

    private void SubscribeToEvents()
    {
        _gameManager.OnReloadScene += ReloadScene;
    }

    private void UnsubscribeToEvents()
    {
        _gameManager.OnReloadScene -= ReloadScene;
    }

    private void EnableLoadingScreen()
    {
        _loadingScreen.SetActive(false);
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            yield return null;
        }
    }
}