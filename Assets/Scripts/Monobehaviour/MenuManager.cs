using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Collections;

public sealed class MenuManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cam1;
    [SerializeField] private Transform _screen;
    [SerializeField] private SceneLoader sceneLoader;

    [Header("Buttons")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _cam1.gameObject.SetActive(false);
        _screen.LeanMoveLocalY(0, 2).setEaseInOutBack();
        _playButton.onClick.AddListener(HandlePlayButtonClick);
        _exitButton.onClick.AddListener(HandleQuitButtonClick);
    }

    private void HandlePlayButtonClick()
    {
        sceneLoader.LoadScene("EndlessScene");
    }

    private void HandleQuitButtonClick()
    {
        Quit();
    }

    private void Quit()
    {
        Application.Quit();
    }
}
