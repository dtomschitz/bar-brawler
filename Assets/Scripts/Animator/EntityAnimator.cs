﻿using System;
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
    
    public void SetWeapon(WeaponType type)
    {
        int currentWeaponType = animator.GetInteger("weapon");
        int newWeaponType = (int)type;

        if (currentWeaponType == newWeaponType) return;

        animator.SetInteger("weapon", newWeaponType);
    }
}