public interface ICollectable
{
    public bool HasBeenCollected { get; set; }
    public abstract void Collect();
    public abstract void EnableMe();
    public abstract void DisableMe();
    public CollectableIndicator GetCollectableIndicator();
}
