using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

/// <summary>
/// Applies the mobile frame pacing configuration before the first scene starts
/// and keeps it active after scene transitions.
/// </summary>
public sealed class MobilePerformanceBootstrap : MonoBehaviour
{
    private const int TargetFrameRate = 60;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Create()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        GameObject bootstrapObject = new GameObject(nameof(MobilePerformanceBootstrap));
        DontDestroyOnLoad(bootstrapObject);
        bootstrapObject.AddComponent<MobilePerformanceBootstrap>();
#endif
    }

    private void Awake()
    {
        ApplySettings();
        SceneManager.sceneLoaded += HandleSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= HandleSceneLoaded;
    }

    private static void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplySettings();
    }

    private static void ApplySettings()
    {
        QualitySettings.vSyncCount = 0;
        OnDemandRendering.renderFrameInterval = 1;
        Application.targetFrameRate = TargetFrameRate;
    }
}
