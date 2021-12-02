using UnityEngine;

public sealed class PlayerInteractionHandler : MonoBehaviour
{
    [SerializeField] private CollectableOnUI[] _coinUIEffect;

    private PlayerHealthHandler _healthHandler;

    private void Awake()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerInteractions(other);
    }

    public void Init()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        _healthHandler = this.GetComponent<PlayerHealthHandler>();
    }

    private void TriggerInteractions(Collider other)
    {
        CheckForCollectable(other);
        CheckForObstacle(other);
    }

    private void CheckForCollectable(Collider other)
    {
        ICollectable collectable = other.GetComponent<ICollectable>();
        if (collectable != null && !collectable.HasBeenCollected)
        {
            collectable.Collect();
            PlayCollectEffectOnUI(collectable);
        }
    }

    private void PlayCollectEffectOnUI(ICollectable collectable)
    {
        CollectableOnUI effect = !_coinUIEffect[0].IsMoving ? _coinUIEffect[0] : _coinUIEffect[1];
        effect.PlayVisualEffect(collectable.GetCollectableIndicatorData());
    }

    private void CheckForObstacle(Collider other)
    {
        IObstacle obstacle = other.GetComponent<IObstacle>();
        if (obstacle != null)
        {
            int damageQtd = obstacle.GetDamageAmount();
            _healthHandler.ReceiveDamage(damageQtd);
        }
    }
}
