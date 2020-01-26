using System;
using System.Collections;
using UnityEngine;

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

    /*public virtual bool OnAttack()
    {
        //StartCoroutine(DoDamge(stats, .15f));
        //OnAttack?.Invoke();
        return false;
    }
    */

    public void Attack(EntityStats stats)
    {
        StartCoroutine(DoDamge(stats, .15f));
        OnAttack?.Invoke();
    }

    public virtual void SetState(CombatState newState)
    {
        if (newState == state || !GameState.instance.IsInGame) return;
        state = newState; 
    }

    IEnumerator DoDamge(EntityStats stats, float delay)
    {
        stats.Damage(entityStats.damage);
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

    public bool IsStunned
    {
        get { return state == CombatState.ATTACKING; }
    }

}

public enum CombatState
{
    IDLE,
    BLOCKING,
    ATTACKING,
    STUNNED
}
