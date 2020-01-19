using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class Fist : WeaponItem
    {
        public override void OnPrimaryAccomplished()
        {
            base.OnPrimaryAccomplished();

            if (combat.IsBlocking) return;

            combat.state = CombatState.ATTACKING;
            StartPrimaryRoutine(PrimaryRoutine());
            animator.OnPrimary();
        }

        public override void OnSecondaryAccomplished()
        {
            base.OnSecondaryAccomplished();

            combat.state = CombatState.BLOCKING;
            StartSecondaryRoutine(BlockingRoutine());
            animator.OnSecondary();
        }

        private IEnumerator BlockingRoutine()
        {
            combat.IsUsingMana = true;
            combat.UseMana();
            combat.state = CombatState.BLOCKING;
            yield return new WaitForSeconds(.1f);
            combat.state = CombatState.IDLE;
            combat.IsUsingMana = false;
        }
    }

}