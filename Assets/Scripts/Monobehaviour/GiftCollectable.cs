using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftCollectable : MonoBehaviour, ICollectable
{
    [SerializeField] private GameObject _mesh;
    [SerializeField] private GameObject _visualEffect;
    [SerializeField] private CollectableIndicator _indicator;
    private bool HasBeenCollected { get; set; }
    public void Collect()
    {
        if(!HasBeenCollected)
        {
            HasBeenCollected = true;
            _mesh.SetActive(false);
            _visualEffect.SetActive(true);
        }
    }

    public CollectableIndicator GetCollectableIndicator()
    {
        return _indicator;
    }
}
