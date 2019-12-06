using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class EntityCombat : MonoBehaviour
{
    public float attackRate = 1f;
    public event System.Action OnAttack;

    public CombatState state;

    CharacterStats playerStats;
    CharacterStats enemyStats;

    void Start()
    {
        playerStats = GetComponent<CharacterStats>();
        state = CombatState.IDLE;
    }

    void Update()
    {
        // attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats stats)
    {
        this.enemyStats = stats;
        StartCoroutine(DoDamge(stats, .15f));
        OnAttack?.Invoke();
    }

    IEnumerator DoDamge(CharacterStats stats, float delay)
    {
        enemyStats.TakeDamage(playerStats.damage);
        yield return new WaitForSeconds(delay);
    }

    public bool IsAttacking()
    {
        return state == CombatState.ATTACKING;
    }
}

public enum CombatState
{
    IDLE,
    ATTACKING
}
