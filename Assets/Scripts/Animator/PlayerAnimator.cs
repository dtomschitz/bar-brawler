using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : EntityAnimator
{
    //public WeaponAnimation[] weaponAnimations;
    //WeaponAnimation currentWeaponAnimation;

    void Awake()
    {
        //currentWeaponAnimation = weaponAnimations[0];
    }

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        animator.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }

    public override void OnAttack()
    {
        base.OnAttack();
    }
}