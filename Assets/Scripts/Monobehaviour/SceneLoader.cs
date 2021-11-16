using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;

    private void Start()
    {
        _loadingScreen.SetActive(false);
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

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //_loadingSlider.value = progress;
            yield return null;
        }
    }
}