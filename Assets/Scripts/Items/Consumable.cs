using System.Collections;
using UnityEngine;
using Utils;

namespace Items
{
    public class Consumable : Equippable
    {
        private PlayerAnimator animator;
        private PlayerCombat combat;

        void Start()
        {
            if (!(item is Drink))
            {
                throw new UnityException("Item is not of the type Drink");
            }

            animator = Player.instance.animator;
            combat = Player.instance.combat;
        }

        public override void OnPrimary()
        {
            PlayerStats stats = Player.instance.stats;
            if (stats == null || stats.HasFullLife || combat.IsDrinking) return;

            //
            //gameObject.SetActive(false);

            animator.OnPrimary();
        }

        public IEnumerator DestroyAfterTime(float time, FunctionUpdater updater = null)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);

            if (updater != null) updater.DestroySelf();
        }
    }
}
