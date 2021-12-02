using System;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    [SerializeField] private StatsSystem _statsSystem;
    [SerializeField] private int _maxHealth = 1;
    [SerializeField] private int _initialHealth = 1;

    public int CurrentHealth { get; private set; }
    public int MaxHealth { get { return _maxHealth; } }

    public Action OnTakeDamage;
    public Action OnDeath;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SetHealthValue(_initialHealth);
    }

    public void SetHealthValue(int value)
    {
        CurrentHealth = value;
    }

    public void ReceiveDamage(int damageQtd) // Called by PlayerInteraction when collided with something
    {
        int remainingLife = CalculateDamage(damageQtd);
        if (remainingLife > 0)
        {
            TakeDamage();
        }
        else
        {
            Die();
        }
        SetDamageOnPlayerStats(damageQtd);
    }
    private int CalculateDamage(int damageQtd)
    {
        return CurrentHealth - damageQtd;
    }

    private void TakeDamage() // Called when collided with something but not died (life > 0)
    {
        OnTakeDamage?.Invoke();
    }

    private void Die() // Called when collided with something and life is now zero
    {
        if (CurrentHealth <= 0) { return; }
        OnDeath?.Invoke();
    }

    private void SetDamageOnPlayerStats(int damageValue) // When taking damage
    {
        _statsSystem.ApplyDamage(damageValue);
    }
}
