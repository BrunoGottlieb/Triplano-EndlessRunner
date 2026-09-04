using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _loadingScreen;

    private bool _persistForSceneTransition;
    private GameObject _persistentTransitionRoot;

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
        PersistForSceneTransition();
        StartCoroutine(LoadSceneAfterLoadingScreenRenders(sceneName));
    }

    public void LoadScene(int sceneIndex)
    {
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(SceneManager.GetSceneAt(sceneIndex).name));
    }

    private void SubscribeToEvents()
    {
        if (_gameManager == null)
        {
            return;
        }

        _gameManager.OnReloadScene += ReloadScene;
    }

    private void UnsubscribeToEvents()
    {
        if (_gameManager == null)
        {
            return;
        }

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

        if (_persistForSceneTransition)
        {
            yield return null;
            Destroy(_persistentTransitionRoot);
        }
    }

    private IEnumerator LoadSceneAfterLoadingScreenRenders(string sceneName)
    {
        Canvas.ForceUpdateCanvases();
        yield return null;
        yield return new WaitForEndOfFrame();
        yield return LoadSceneAsync(sceneName);
    }

    private void PersistForSceneTransition()
    {
        if (_persistForSceneTransition)
        {
            return;
        }

        _persistForSceneTransition = true;
        Canvas loadingCanvas = GetComponentInParent<Canvas>();

        if (loadingCanvas == null)
        {
            Debug.LogError("SceneLoader needs a parent Canvas to display the loading screen.", this);
            _persistForSceneTransition = false;
            return;
        }

        loadingCanvas.transform.SetParent(null, false);
        _persistentTransitionRoot = loadingCanvas.gameObject;
        DontDestroyOnLoad(_persistentTransitionRoot);
    }
}
