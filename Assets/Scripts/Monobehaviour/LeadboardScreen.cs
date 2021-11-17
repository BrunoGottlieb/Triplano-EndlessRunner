using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public sealed class LeadboardScreen : MonoBehaviour
{
    [Header("Layout")]
    [SerializeField] private Transform _panel;
    [SerializeField] private CanvasGroup _blackout;
    [SerializeField] private Button _restartBtn;
    [SerializeField] private GameObject _newBestScoreBandage;

    [Header("My texts")]
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _distanceText;
    [SerializeField] private Text _goldText;
    [SerializeField] private Text _gemText;

    [Header("Scripts")]
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private StatsSystem _statsSystem;

    private void Awake()
    {
        _restartBtn.onClick.AddListener(ReloadScene);
    }

    private void OnEnable()
    {
        _panel.LeanMoveLocal(Vector2.zero, 1f).setEaseInOutBack().setDelay(1);
        _blackout.LeanAlpha(1, 1f).setDelay(0.75f);
        StartCoroutine(SetTextValues());
    }

    private void ScoreHandler()
    {
        SaveSystem.Init();
        int bestScore = SaveSystem.GetBestScore();
        if (_statsSystem.Distance > bestScore)
        {
            bestScore = _statsSystem.Distance;
            SaveSystem.SaveBestScore(bestScore);
            StartCoroutine(ShowBestScoreBandage());
        }
        _bestScoreText.text = "Best score: " + bestScore.ToString("00000") + "m";
    }

    IEnumerator ShowBestScoreBandage() // When player' score is the new best one
    {
        yield return new WaitForSeconds(2);
        _newBestScoreBandage.transform.localScale = new Vector3(10, 10, 10);
        _newBestScoreBandage.SetActive(true);
        _newBestScoreBandage.LeanScale(Vector3.one, 0.4f);
    }

    IEnumerator SetTextValues() // Put player stats on the screen
    {
        yield return new WaitForSeconds(0.25f);
        _goldText.text = _statsSystem.Gold.ToString();
        _distanceText.text = "Score: " + _statsSystem.Distance.ToString("00000") + "m";
        _gemText.text = _statsSystem.Gem.ToString();
        ScoreHandler();
    }

    private void ReloadScene()
    {
        _sceneLoader.ReloadScene();
    }
}
