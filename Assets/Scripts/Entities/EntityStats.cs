using System;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public float maxHealth;
    public float damage;

    public float CurrentHealth { get; protected set; }
    public event Action OnDeath;

    public delegate void TakeDamage(float damage);
    public event TakeDamage OnTakeDamage;

    public virtual void Start()
    {
    }

    public void Init(StatsConfig config)
    {
        if (config != null)
        {
            if (config.maxHealth >= 0f)
            {
                maxHealth = config.maxHealth;
                CurrentHealth = maxHealth;
            }
            if (config.damage >= 0f) damage = config.damage;
        }
    }

    public virtual void Damage(float damage)
    {
        damage = Mathf.Clamp(damage, 0, maxHealth);
        CurrentHealth -= damage;
        OnTakeDamage?.Invoke(damage);
        FindObjectOfType<AudioManager>().Play("Punch");
        FindObjectOfType<AudioManager>().Play("FightReaction");
        if (IsDead)
        {
            OnDeath?.Invoke();
        }
    }

    public virtual void Heal(float amount)
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