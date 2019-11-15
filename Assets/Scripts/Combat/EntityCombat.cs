using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class EntityCombat : MonoBehaviour
{

    public float attackRate = 1f;
    public event System.Action OnAttack;

    CharacterStats playerStats;
    CharacterStats enemyStats;

    void Start()
    {
        playerStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        // attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats stats)
    {
        this.enemyStats = stats;
        StartCoroutine(DoDamge(stats, .15f));


        if (OnAttack != null)
        {
            OnAttack();
        }
    }

    IEnumerator DoDamge(CharacterStats stats, float delay)
    {
        Debug.Log(transform.name + " damage: " + playerStats.damage);
        enemyStats.TakeDamage(playerStats.damage);
        yield return new WaitForSeconds(delay);
    }
}
