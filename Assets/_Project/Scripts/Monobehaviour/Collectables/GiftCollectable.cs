using UnityEngine;

public class GiftCollectable : MonoBehaviour, ICollectable
{
    [SerializeField] private GameObject _mesh;
    [SerializeField] private GameObject _visualEffect;
    [SerializeField] private CollectableIndicatorData _indicator;
    public bool HasBeenCollected { get; set; }
    public void Collect() // Triggered by player interaction
    {
        if(!HasBeenCollected)
        {
            DisableMe();
        }
    }

    public void DisableMe() // Called after collected
    {
        HasBeenCollected = true;
        _mesh.SetActive(false);
        _visualEffect.SetActive(true);
    }

    public void EnableMe() // Called by content father in every collectable when the clock is enabled
    {
        HasBeenCollected = false;
        _mesh.SetActive(true);
        _visualEffect.SetActive(false);
    }

    public CollectableIndicatorData GetCollectableIndicatorData() // Get the icon of this collectable item
    {
        return _indicator;
    }
}
