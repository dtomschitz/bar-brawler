using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EntityStats))]
public class EntityCombat : MonoBehaviour
{
    //private float attackCooldown = 0f;
    public event Action OnAttack;

    public CombatState state;

    private EntityStats entityStats;
    private EntityStats enemyStats;

    void Start()
    {
        entityStats = GetComponent<EntityStats>();
        state = CombatState.IDLE;
    }

    public void Attack(EntityStats stats)
    {
        enemyStats = stats;
        StartCoroutine(DoDamge(.15f));
        OnAttack?.Invoke();
    }

    IEnumerator DoDamge(float delay)
    {
        enemyStats.TakeDamage(entityStats.damage.GetValue);
        yield return new WaitForSeconds(delay);
    }

    public bool IsAttacking
    {
        get { return state == CombatState.ATTACKING; }
    }
}

public enum CombatState
{
    IDLE,
    ATTACKING
}
