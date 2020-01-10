using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverlay : MonoBehaviour
{
    public PlayerStats stats;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        stats.OnTakeDamage += OnTakeDamage;
    }

    public void OnTakeDamage(double damage)
    {
        animator.SetTrigger("damage");
    }
}
