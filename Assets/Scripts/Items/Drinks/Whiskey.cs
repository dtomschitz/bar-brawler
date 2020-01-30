using UnityEngine;
using Utils;

namespace Items
{
    public class Whiskey : Consumable
    {
        public override void OnPrimary()
        {
            base.OnPrimary();

            /*float amount = 0f;
            float healingAmount = (item as Drink).healingAmount;

            float rate = (healingAmount / 100f) * Time.deltaTime * 10f;

            FunctionUpdater functionUpdater = FunctionUpdater.Create(() =>
            {
                //amount = Mathf.Lerp(0, healingAmount, 1f);
                if (amount == healingAmount) return;

                amount += rate;

                //amount = rate * Time.deltaTime * 10f;
                //amount = Mathf.Clamp(amount, 0, healingAmount);

                Player.instance.stats.Heal(rate);
            });

            DestroyAfterTime(2f, functionUpdater);*/
        }
    }
}

