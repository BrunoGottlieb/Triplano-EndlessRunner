using UnityEngine;

public sealed class KillableObstacle : MonoBehaviour, IObstacle
{
    private readonly int _damage = 2;

    public int GetDamageAmount()
    {
        return _damage;
    }
}
