using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int maxHealth;
    public int damage;

    public int currentHealth { get; protected set; }
    public event System.Action OnHealthIsZero;

    public virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void Start()
    {
        
    }

    public void TakeDamage(int damage)
    {
        //Make sure damage doesn't go below 0;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        if (isDead())
        {
            if (OnHealthIsZero != null)
            {
                OnHealthIsZero();
            }
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public bool isDead()
    {
        return currentHealth <= 0;
    }
}
