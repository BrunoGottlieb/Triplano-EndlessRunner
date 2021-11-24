using Cinemachine;
using System.Collections;
using UnityEngine;

public sealed class CameraShaker : MonoBehaviour
{
    public static CameraShaker Instance { get { return _instance; } }
    private static CameraShaker _instance;
    private CinemachineVirtualCamera _vcam;
    private CinemachineBasicMultiChannelPerlin _noise;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        InitInstance();
        GetReferences();
    }

    private void InitInstance()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogError("Not supposed to have more than one instance of CameraShaker on scene");
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        _vcam = this.GetComponent<CinemachineVirtualCamera>();
        _noise = _vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float amplitudeGain, float frequencyGain, float duration)
    {
        StartCoroutine(Noise(amplitudeGain, frequencyGain, duration));
    }

    private IEnumerator Noise(float amplitudeGain, float frequencyGain, float duration)
    {
        _noise.m_AmplitudeGain = amplitudeGain;
        _noise.m_FrequencyGain = frequencyGain;
        yield return new WaitForSeconds(duration);
        _noise.m_AmplitudeGain = 0;
        _noise.m_FrequencyGain = 0;
    }

}
