using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityStats))]
public class EntityCombat : MonoBehaviour
{
    public float attackRate = 1f;
    public event System.Action OnAttack;

    public CombatState state;

    private EntityStats entityStats;
    private EntityStats enemyStats;

    void Start()
    {
        entityStats = GetComponent<EntityStats>();
        state = CombatState.IDLE;
    }

    void Update()
    {
        // attackCooldown -= Time.deltaTime;
    }

    public void Attack(EntityStats stats)
    {
        enemyStats = stats;
        StartCoroutine(DoDamge(stats, .15f));
        OnAttack?.Invoke();
    }

    IEnumerator DoDamge(EntityStats stats, float delay)
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
