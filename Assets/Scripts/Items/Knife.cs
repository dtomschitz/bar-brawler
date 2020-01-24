using System.Collections;
using UnityEngine;

namespace Items
{
    public class Knife : WeaponItem
    {

        [Header("Knife Attributes")]
        public float bleedOutDamage = 2f;
        public float bleedOutTime = 10f;
        public float timeBetweenDamage = 1f;

        public override void OnPrimaryAccomplished()
        {
            base.OnPrimaryAccomplished();

            //combat.state = CombatState.ATTACKING;
            StartPrimaryRoutine(PrimaryRoutine());
            animator.OnPrimary();
        }

        public override void OnHit(Enemy enemy)
        {
            base.OnHit(enemy);
            StartCoroutine(KnifeBleedOut(enemy));

        }

        private IEnumerator KnifeBleedOut(Enemy enemy)
        {
            var pastTime = 0f;
            while (pastTime < bleedOutTime)
            {
                enemy.Stats.Damage(bleedOutDamage);
                pastTime++;
                yield return new WaitForSeconds(timeBetweenDamage);
            }
        }
    }

}