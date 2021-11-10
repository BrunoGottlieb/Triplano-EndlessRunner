using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UI Indicator", menuName = "Collectable UI Indicator")]
public class CollectableIndicator : ScriptableObject
{
    public string type;
    public Sprite icon;
}
