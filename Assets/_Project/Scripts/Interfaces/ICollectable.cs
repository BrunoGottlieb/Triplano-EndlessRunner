public interface ICollectable
{
    public bool HasBeenCollected { get; set; }
    public void Collect();
    public void EnableMe();
    public void DisableMe();
    public CollectableIndicatorData GetCollectableIndicatorData();
}
