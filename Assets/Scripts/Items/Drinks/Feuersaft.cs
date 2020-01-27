using Utils;

namespace Items
{
    public class Feuersaft : Consumable
    {
        public override void OnPrimary()
        {
            base.OnPrimary();
            Player.instance.stats.Heal((item as Drink).healingAmount);

        }
    }
}
