using UnityEngine;

[CreateAssetMenu(fileName = "New UI Indicator", menuName = "Collectable UI Indicator")]
public sealed class CollectableIndicator : ScriptableObject
{
    public string type;
    public Sprite icon;
}
