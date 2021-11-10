using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftCollectable : MonoBehaviour, ICollectable
{
    public GameObject mesh;
    public GameObject visualEffect;
    private bool HasBeenCollected { get; set; }
    public void Collect()
    {
        if(!HasBeenCollected)
        {
            HasBeenCollected = true;
            mesh.SetActive(false);
            visualEffect.SetActive(true);
        }
    }
}
