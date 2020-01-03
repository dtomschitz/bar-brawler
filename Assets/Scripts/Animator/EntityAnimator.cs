using System;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    public Animator animator;

    protected virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public virtual void OnAttack()
    {
        animator.SetTrigger("attack");
    }

    public virtual void OnDeath()
    {
        animator.SetTrigger("death");
    }
    
    public void SetItem(Items type)
    {
        int currentWeaponType = animator.GetInteger("item");
        int newWeaponType = (int)type;

        if (currentWeaponType == newWeaponType) return;

        animator.SetInteger("item", newWeaponType);
    }
}