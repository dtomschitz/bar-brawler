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
        animator.SetFloat("VelocityX", Input.GetAxis("Horizontal"));
        animator.SetFloat("VelocityY", Input.GetAxis("Vertical"));
        //animator.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }

    public override void OnPrimary()
    {
        base.OnPrimary();
    }
}