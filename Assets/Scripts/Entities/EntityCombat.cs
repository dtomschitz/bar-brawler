using System;
using System.Collections;
using UnityEngine;
using Items;

public class EntityCombat : MonoBehaviour
{
    public event Action OnAttack;
    public CombatState state { get; protected set; }

    private EntityStats entityStats;

    protected virtual void Start()
    {
        entityStats = GetComponent<EntityStats>();
        state = CombatState.IDLE;
    }

    public virtual void Attack(EntityStats stats)
    {
        StartCoroutine(DoDamge(stats, .15f));
        OnAttack?.Invoke();
    }

    public void SetState(CombatState newState)
    {
        if (newState == state || !GameState.instance.IsInGame) return;
        state = newState; 

        switch(newState)
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
        }
    }

    IEnumerator DoDamge(EntityStats stats, float delay)
    {
        stats.Damage(entityStats.damage.Value);
        yield return new WaitForSeconds(delay);
    }

    public bool IsAttacking
    {
        get { return state == CombatState.ATTACKING; }
    }

    public bool IsBlocking
    {
        get { return state == CombatState.BLOCKING; }
    }
}

public enum CombatState
{
    IDLE,
    BLOCKING,
    ATTACKING
}
