using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftCollectable : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        print("A");
        this.gameObject.SetActive(false);
    }
}
