using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableOnUI : MonoBehaviour
{
    public Transform targetPos;

    private void OnEnable()
    {
        print("fds: " + targetPos.localPosition);
        transform.LeanMoveLocal(targetPos.localPosition, 1);
    }
}
