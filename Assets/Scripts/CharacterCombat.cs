using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackRate = 1f;
    private float attackCountdown = 0f;

    public event System.Action onAttack;

    CharacterStats playerStats;
    CharacterStats enemyStats;

    void Start()
    {
        playerStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        attackCountdown -= Time.deltaTime;
    }

    public void Attack(CharacterStats enemyStats)
    {
        if (attackCountdown <= 0f)
        {
            this.enemyStats = enemyStats;
            attackCountdown = 1f / attackRate;

            StartCoroutine(DoDamge(enemyStats, .15f));
        }
    }

    IEnumerator DoDamge(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log(transform.name + " damage: " + playerStats.damage);
        enemyStats.TakeDamage(playerStats.damage);
    }
}
