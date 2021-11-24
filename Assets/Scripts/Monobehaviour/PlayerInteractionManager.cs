using UnityEngine;

public sealed class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private CollectableOnUI[] _coinUIEffect;
    [SerializeField] private LeadboardScreen _leadboardScreen;

    private PlayerController _playerController;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        _playerController = this.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerInteractions(other);
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
        effect.PlayVisualEffect(collectable.GetCollectableIndicator());
    }

    private void CheckForObstacle(Collider other)
    {
        IObstacle obstacle = other.GetComponent<IObstacle>();
        if (obstacle != null)
        {
            int damageQtd = obstacle.GetDamageAmount();
            _playerController.ReceiveDamage(damageQtd);
        }
    }
}
