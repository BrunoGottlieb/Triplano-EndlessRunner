using Cinemachine;
using System.Collections;
using UnityEngine;

public sealed class CameraShaker : MonoBehaviour
{
    private static CameraShaker _instance;
    public static CameraShaker Instance { get { return _instance; } }

    private CinemachineVirtualCamera vcam;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        vcam = this.GetComponent<CinemachineVirtualCamera>();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float amplitudeGain, float frequencyGain, float duration)
    {
        StartCoroutine(Noise(amplitudeGain, frequencyGain, duration));
    }

    private IEnumerator Noise(float amplitudeGain, float frequencyGain, float duration)
    {
        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_FrequencyGain = frequencyGain;
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }

}
