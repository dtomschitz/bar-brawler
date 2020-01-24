using UnityEngine;

public class PlayerCombat : EntityCombat
{
    public const int MAX_MANA = 100;
    public float manaRegenerationAmount;
    public float manaRegenerationSpeed;

    public float CurrentMana { get; protected set; }
    public bool IsUsingMana { get; set; }


    protected override void Start()
    {
        base.Start();
        CurrentMana = MAX_MANA;
    }

    void Update()
    {
        if (!IsUsingMana) AddMana(manaRegenerationAmount * Time.deltaTime / manaRegenerationSpeed);
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