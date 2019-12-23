using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : EntityCombat
{
    public const int MAX_MANA = 100;
    public float manaRegenerationAmount;

    private float currentMana;

    protected override void Start()
    {
        base.Start();
        currentMana = 0;
    }

    void Update()
    {
        currentMana += manaRegenerationAmount * Time.deltaTime;
        currentMana = Mathf.Clamp(currentMana, 0f, MAX_MANA);
    }

    public void UseMana(int amount)
    {
        if (currentMana >= amount) {
            currentMana -= amount;
        }
    }

    public float ManaNormalized
    {
        get { return currentMana / MAX_MANA; }
    }

    public float CurrentMana
    {
        get { return currentMana; }
    }
}