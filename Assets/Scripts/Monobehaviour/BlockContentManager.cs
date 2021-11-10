using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BlockContentManager : MonoBehaviour
{
    [SerializeField] private Transform collectableGroup;
    private ICollectable[] collectables;

    private void Awake()
    {
        collectables = new ICollectable[collectableGroup.childCount];
        if(collectables.Length > 0 && collectables[0] == null) // Fill the array on the first time executing
        {
            collectables = collectableGroup.GetComponentsInChildren<ICollectable>();
        }
    }

    private void OnEnable()
    {
        foreach(ICollectable item in collectables) // enable all collectables items
        {
            item.EnableMe();
        }
    }
}
