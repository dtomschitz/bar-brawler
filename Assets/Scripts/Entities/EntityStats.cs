﻿using System;
using UnityEngine;
using Items;

public class EntityStats : MonoBehaviour
{
    public float maxHealth;
    public float damage;

    public float CurrentHealth { get; protected set; }
    public event Action OnDeath;

    public delegate void Damaged(float damage, Equipment item = null);
    public event Damaged OnDamaged;

    public delegate void Healed(float amount);
    public event Healed OnHealed;

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

    public virtual void Damage(float damage, Equipment item = null)
    {
        damage = Mathf.Clamp(damage, 0, maxHealth);
        CurrentHealth -= damage;
        OnDamaged?.Invoke(damage, item);

        //FindObjectOfType<AudioManager>().Play("Punch");

        if (IsDead) OnDeath?.Invoke();
    }

    public virtual void Heal(float amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);

        OnHealed?.Invoke(amount);
    }

    public float HealthNormalized
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