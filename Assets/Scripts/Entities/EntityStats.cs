using System;
using UnityEngine;
using UnityEngine.UI;

public class EntityStats : MonoBehaviour
{

    public float maxHealth;
    public Stat damage;

    public float CurrentHealth { get; protected set; }
    public event Action OnDeath;

    public delegate void TakeDamage(double damage);
    public event TakeDamage OnTakeDamage;

    public virtual void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public virtual void Start()
    {
    }

    public virtual void Damage(float damage)
    {
        damage = Mathf.Clamp(damage, 0, float.MaxValue);
        CurrentHealth -= damage;
        OnTakeDamage?.Invoke(damage);
        FindObjectOfType<AudioManager>().Play("Punch");
        FindObjectOfType<AudioManager>().Play("FightReaction");
        if (IsDead)
        {
            OnDeath?.Invoke();
        }
    }

    public void Heal(float amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
    }

    public float NormalizedHealth
    {
        get { return CurrentHealth / maxHealth; }
    }

    public bool HasFullLife
    {
        get { return CurrentHealth == maxHealth; }
    }

    public bool IsDead
    {
        get { return CurrentHealth <= 0; }
    }
}
