using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EntityStats))]
public class EntityCombat : MonoBehaviour
{
    public event Action OnAttack;
    public CombatState state;

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
