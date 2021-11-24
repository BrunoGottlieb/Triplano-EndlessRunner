using UnityEngine;

public sealed class PlayerSoundManager : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioSource _slideSource;
    [SerializeField] private AudioSource _airSource;
    [SerializeField] private AudioSource _jumpSource;

    public void PlaySlideSound()
    {
        if (!_slideSource.isPlaying)
        {
            _slideSource.Play();
        }
    }

    public void PlayAirSound()
    {
        if (!_airSource.isPlaying)
        {
            _airSource.Play();
        }
    }

    public void PlayJumpSound()
    {
        if(!_jumpSource.isPlaying)
        {
            _jumpSource.Play();
        }
    }

}
