using System.Collections.Generic;
using UnityEngine;
using Items;

public class PlayerCombat : EntityCombat
{
    public int simultaneousAttackers = 1;

    public const int MAX_MANA = 100;
    public float manaRegenerationAmount;
    public float manaRegenerationSpeed;

    public float CurrentMana { get; protected set; }
    public bool IsUsingMana { get; set; }

    private List<GameObject> attackers;


    protected override void Start()
    {
        base.Start();

        attackers = new List<GameObject>();
        CurrentMana = MAX_MANA;
    }

    void Update()
    {
        if (!IsUsingMana) AddMana(manaRegenerationAmount * Time.deltaTime / manaRegenerationSpeed);
    }

    public void OnRequestAttack(GameObject enemy)
    {
        attackers.RemoveAll(item => item == null);

        if (attackers.Count < simultaneousAttackers)
        {
            if (!attackers.Contains(enemy)) attackers.Add(enemy);
            enemy.SendMessage("OnAllowAttack", gameObject);
            Debug.Log("Attack accepted, current attackers: " + attackers.Count);
        }
        else
        {
            Debug.Log("Attack REJECTED, current attackers: " + attackers.Count);
        }
    }

    public void OnCancelAttack(GameObject enemy)
    {
        attackers.Remove(enemy);
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

    public override void SetState(CombatState newState)
    {
        base.SetState(newState);

        switch (newState)
        {
            case CombatState.ATTACKING:
                Player.instance.controls.IsMovementEnabled = !(Player.instance.equipment.CurrentItem is Fist);
                break;

            case CombatState.BLOCKING:
                Player.instance.controls.IsMovementEnabled = !(Player.instance.equipment.CurrentItem is Fist);
                break;

            case CombatState.IDLE:
                Player.instance.controls.IsMovementEnabled = true;
                break;

            case CombatState.STUNNED:
                Player.instance.controls.IsMovementEnabled = false;
                break;

        }
    }

    public float NormalizedMana
    {
        get { return CurrentMana / MAX_MANA; }
    }

    private void OnDrawGizmos()
    {
        if (attackers != null)
        {
            foreach (GameObject attacker in attackers)
            {
                if (attacker != null)
                {
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawWireSphere(attacker.transform.position, 1.0f);
                }
            }
        }
    }
}