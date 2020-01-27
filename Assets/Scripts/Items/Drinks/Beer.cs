using Utils;

namespace Items
{
    public class Beer : Consumable
    {
        public override void OnPrimary()
        {
            base.OnPrimary();
            FunctionUpdater.Create(() =>
            {
                Player.instance.stats.Heal((item as Drink).healingAmount);
            });
        }
    }
}
