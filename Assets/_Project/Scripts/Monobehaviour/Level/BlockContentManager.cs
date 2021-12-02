using UnityEngine;

public sealed class BlockContentManager : MonoBehaviour
{
    [SerializeField] private Transform _collectableGroup;
    private ICollectable[] _collectables;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        EnableAllCollectables();
    }

    public void Init()
    {
        FillCollectableArray();
    }

    private void FillCollectableArray()
    {
        _collectables = new ICollectable[_collectableGroup.childCount];
        if (_collectables.Length > 0 && _collectables[0] == null) // Fill the array on the first time executing
        {
            _collectables = _collectableGroup.GetComponentsInChildren<ICollectable>();
        }
    }

    private void EnableAllCollectables()
    {
        foreach (ICollectable item in _collectables)
        {
            item.EnableMe();
        }
    }
}
