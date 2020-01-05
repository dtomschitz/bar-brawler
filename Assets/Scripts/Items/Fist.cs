using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : WeaponItem
{
    public override void OnPrimaryAccomplished()
    {
        combat.state = CombatState.ATTACKING;
        StartPrimaryRoutine(PrimaryRoutine());
        animator.OnPrimary();
    }

    public override void OnSecondaryAccomplished()
    {
        combat.state = CombatState.BLOCKING;
        StartSecondaryRoutine(BlockingRoutine());
        animator.OnSecondary();
        combat.UseMana();
    }

    private IEnumerator BlockingRoutine()
    {
        combat.state = CombatState.BLOCKING;
        yield return new WaitForSeconds(1f);
        combat.state = CombatState.IDLE;
    }
}
