using UnityEngine;

public sealed class LeadboardScreen : MonoBehaviour
{
    [SerializeField] private Transform _panel;
    [SerializeField] private CanvasGroup _blackout;

    private void OnEnable()
    {
        _panel.LeanMoveLocal(Vector2.zero, 1f).setEaseInOutBack().setDelay(1);
        _blackout.LeanAlpha(1, 1f).setDelay(0.75f);
    }
}
