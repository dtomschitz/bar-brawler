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
            if (owner.combat.IsAttacking || owner.combat.IsBlocking || owner.combat.IsDrinking || owner.stats.HasFullLife) return;

            owner.animator.OnPrimary();
            StartCoroutine(StartHealing(item as Drink));
        }

        private IEnumerator StartHealing(Drink drink)
        {
            yield return new WaitForSeconds(drink.healingDelay);
            owner.stats.Heal(drink.healingAmount);

            Player.instance.inventory.RemoveItem(item);
        }
    }
}
