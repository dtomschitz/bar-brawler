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
        CurrentMana = 0;
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

    public void UseMana(float amount)
    {
        if (CurrentMana >= amount) {
            CurrentMana -= amount;
        }
    }

    public float ManaNormalized
    {
        get { return CurrentMana / MAX_MANA; }
    }
}