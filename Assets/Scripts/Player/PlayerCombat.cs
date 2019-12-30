using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : EntityCombat
{
    public const int MAX_MANA = 100;
    public float manaRegenerationAmount;
    public float manaRegenerationSpeed;

    public float CurrentMana { get; protected set; }

    protected override void Start()
    {
        base.Start();
        CurrentMana = MAX_MANA;
    }

    void Update()
    {
        AddMana(manaRegenerationAmount * Time.deltaTime / manaRegenerationSpeed);
    }

    public override void Attack(EntityStats stats)
    {
        base.Attack(stats);
        AddMana(10);
    }

    public void AddMana(float amount)
    {
        CurrentMana += amount;
        CurrentMana = Mathf.Clamp(CurrentMana, 0f, MAX_MANA);
    }

    public void UseMana(float amount = 1f)
    {
        amount = Mathf.Clamp(amount, 0, float.MaxValue);
        CurrentMana -= amount;
    }

    public float NormalizedMana
    {
        get { return CurrentMana / MAX_MANA; }
    }
}