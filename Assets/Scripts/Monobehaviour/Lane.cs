using UnityEngine;

public sealed class Lane : MonoBehaviour
{
    private void Awake()
    {
        DisableLaneVisual();
    }

    private void DisableLaneVisual()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
}
