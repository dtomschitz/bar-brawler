using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : EntityCombat
{
    public int simultaneousAttackers = 1;

    private List<GameObject> attackers;

    protected override void Start()
    {
        base.Start();

        attackers = new List<GameObject>();
        CurrentMana = MAX_MANA;
    }

    protected override void Update()
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

    public override void SetState(CombatState newState)
    {
        base.SetState(newState);
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