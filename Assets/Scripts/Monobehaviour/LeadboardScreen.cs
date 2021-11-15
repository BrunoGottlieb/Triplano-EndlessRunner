using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class LeadboardScreen : MonoBehaviour
{
    [SerializeField] private Transform _panel;
    [SerializeField] private CanvasGroup _blackout;
    [SerializeField] private Button _restartBtn;
    [SerializeField] private GameObject _loadingScreen;

    private void Awake()
    {
        _restartBtn.onClick.AddListener(ReloadScene);
        _loadingScreen.SetActive(false);
    }

    private void OnEnable()
    {
        _panel.LeanMoveLocal(Vector2.zero, 1f).setEaseInOutBack().setDelay(1);
        _blackout.LeanAlpha(1, 1f).setDelay(0.75f);
    }

    private void ReloadScene()
    {
        _loadingScreen.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
