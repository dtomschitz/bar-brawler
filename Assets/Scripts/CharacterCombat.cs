using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackRate = 1f;
    private float attackCooldown = 0f;

    public event System.Action OnAttack;

    CharacterStats playerStats;
    CharacterStats enemyStats;

    void Start()
    {
        playerStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats stats)
    {
        if (attackCooldown <= 0f)
        {
            this.enemyStats = stats;
            attackCooldown = 0f;
            DoDamge(stats, .15f);

            if (OnAttack != null)
            {
                OnAttack();
            }
        }
    }

    void DoDamge(CharacterStats stats, float delay)
    {
        //yield return new WaitForSeconds(delay);
        Debug.Log(transform.name + " damage: " + playerStats.damage);
        enemyStats.TakeDamage(playerStats.damage);
    }
}
