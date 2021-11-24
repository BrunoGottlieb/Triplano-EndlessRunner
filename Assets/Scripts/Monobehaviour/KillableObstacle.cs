using UnityEngine;

public sealed class DamageableObstacle : MonoBehaviour, IObstacle
{
    private readonly int _damage = 1;
    public int GetDamageAmount()
    {
        return _damage;
    }

}
