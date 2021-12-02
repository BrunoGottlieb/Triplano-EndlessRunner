using Cinemachine;
using System.Collections;
using UnityEngine;

public sealed class CameraShaker : MonoBehaviour
{
    private CinemachineVirtualCamera _vcam;
    private CinemachineBasicMultiChannelPerlin _noise;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        GetReferences();
    }

    public void Shake(float amplitudeGain, float frequencyGain, float duration)
    {
        StartCoroutine(Noise(amplitudeGain, frequencyGain, duration));
    }

    private void GetReferences()
    {
        _vcam = this.GetComponent<CinemachineVirtualCamera>();
        _noise = _vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
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
