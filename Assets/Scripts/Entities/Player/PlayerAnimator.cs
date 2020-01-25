﻿using Items;
using UnityEngine;

public class PlayerAnimator : EntityAnimator
{
    protected override void Start()
    {
        base.Start();

        Player.instance.equipment.OnItemEquipped += OnItemEquipped;
    }

    public void OnItemEquipped(Equipment newItem, Equipment oldItem) => SetEquipment(newItem);

    public void SetForward(float forward)
    {
        animator.SetFloat("Forward", forward);
    }


    public void SetStrafe(float strafe)
    {
        animator.SetFloat("Strafe", strafe);
    }

    public override void OnPrimary()
    {
        base.OnPrimary();
    }
}