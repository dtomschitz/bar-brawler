using System.Collections;
using UnityEngine;
using Items;
using System;

/// <summary>
/// Displays the damage overlay for a set time if the player got hit by an enemy.
/// </summary>
public class DamageOverlay : MonoBehaviour
{
    public float time = 1f;

    private EntityStats stats;
    private Animator animator;

    void Start()
    {
        stats = Player.instance.stats;
        if (stats == null) throw new ArgumentException("Player stats class cannot be null");

        animator = GetComponent<Animator>();
        stats.OnDamaged += OnTakeDamage;
    }

    /// <summary>Gets called when the player took damage.</summary>
    /// <param name="damage">The ammount of damage the player took</param>
    /// <param name="item">The item of which the player took the damage</param>
    void OnTakeDamage(float damage, Equipment item)
    {
        if (GameState.instance.IsInGame)
        {
            StopAllCoroutines();
            StartCoroutine(ShowDamgeOverlay());
        }
    }

    /// <summary>Displays the damage overlay for the specified time.</summary>
    /// <returns></returns>
    IEnumerator ShowDamgeOverlay()
    {
        animator.SetBool("damage", true);
        yield return new WaitForSeconds(time);
        animator.SetBool("damage", false);
    }
}
