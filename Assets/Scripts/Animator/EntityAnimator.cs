using System;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    public Animator animator;
    public EntityCombat combat;

    protected virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<EntityCombat>();
        //combat.OnAttack += OnAttack;
    }

    public virtual void OnAttack()
    {
        animator.SetTrigger("attack");
    }
    
    public void SetWeapon(WeaponType type)
    {
        Debug.Log((int)type);
        animator.SetInteger("weapon", (int) type);
    }
}