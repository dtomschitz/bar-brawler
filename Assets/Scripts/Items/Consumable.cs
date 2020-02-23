using System.Collections;
using UnityEngine;
using Utils;

namespace Items
{
    /// <summary>
    /// Class <c>Consumable</c> is used for all game objects which could be equipped
    /// and consumed by the player.
    /// </summary>
    public class Consumable : Equippable
    {
        public override void OnPrimary()
        {
            base.OnPrimary();
            if (owner.combat.IsAttacking || owner.combat.IsBlocking || owner.combat.IsDrinking || owner.stats.HasFullLife) return;

            owner.animator.OnPrimary();
            StartCoroutine(StartHealing(item as Drink));
        }

        /// <summary>
        /// Starts the healing process after the given delay.
        /// </summary>
        /// <param name="drink">The drink which the player consumed.</param>
        private IEnumerator StartHealing(Drink drink)
        {
            yield return new WaitForSeconds(drink.healingDelay);
            owner.stats.Heal(drink.healingAmount);
        }
    }
}