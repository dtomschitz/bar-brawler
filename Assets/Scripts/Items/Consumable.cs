using System.Collections;
using UnityEngine;
using Utils;

namespace Items
{
    public class Consumable : Equippable
    {
        private PlayerAnimator animator;

        void Start()
        {
            if (!(item is Drink))
            {
                throw new UnityException("Item is not of the type Drink");
            }

            animator = Player.instance.animator;
        }

        public override void OnPrimary()
        {
            PlayerStats stats = Player.instance.stats;
            if (stats == null || stats.HasFullLife) return;

            Player.instance.inventory.RemoveItem(item);
            gameObject.SetActive(false);
        }

        public IEnumerator DestroyAfterTime(float time, FunctionUpdater updater = null)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);

            if (updater != null) updater.DestroySelf();
        }
    }
}
