using System.Collections;
using UnityEngine;
using Utils;

namespace Items
{
    public class Consumable : Equippable
    {
        public override void OnPrimary()
        {
            base.OnPrimary();
            if (owner.stats == null || owner.stats.HasFullLife || owner.combat.IsAttacking || owner.combat.IsBlocking || owner.combat.IsDrinking) return;
            owner.animator.OnPrimary();
        }

        public IEnumerator DestroyAfterTime(float time, FunctionUpdater updater = null)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);

            if (updater != null) updater.DestroySelf();
        }
    }
}
