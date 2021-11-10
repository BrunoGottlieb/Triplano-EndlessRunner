using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerSoundManager : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource _slideSource;
    public AudioSource _airSource;
    public AudioSource _jumpSource;

    private InputManager _inputManager;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
        _inputManager.OnSlide += PlaySlideSound;
        _inputManager.OnJump += PlayJumpSound;
        _inputManager.OnMoveLeft += PlayAirSound;
        _inputManager.OnMoveRight += PlayAirSound;
    }

    private void PlaySlideSound()
    {
        if (!_slideSource.isPlaying)
        {
            _slideSource.Play();
        }
    }

    private void PlayAirSound()
    {
        if (!_airSource.isPlaying)
        {
            _airSource.Play();
        }
    }

    private void PlayJumpSound()
    {
        if(!_jumpSource.isPlaying)
        {
            _jumpSource.Play();
        }
    }

}
