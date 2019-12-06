using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{

    public int maxHealth;
    public Stat damage;

    public int CurrentHealth { get; protected set; }
    public event System.Action OnHealthIsZero;

    public virtual void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public virtual void Start()
    {  
    }

    public void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        CurrentHealth -= damage;
        if (IsDead)
        {
            OnHealthIsZero?.Invoke();
        }
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
    }

    public bool IsDead
    {
        get { return CurrentHealth <= 0; }
    }
}
