using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    public Animator animator;

    EntityCombat combat;

    protected virtual void Start()
    {
        combat = GetComponent<EntityCombat>();
        combat.OnAttack += OnAttack;
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("Attack");
    }
}
