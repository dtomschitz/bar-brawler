using Utils;

namespace Items
{
    public class Beer : Consumable
    {
        public float timer;

        public override void OnPrimary()
        {
            base.OnPrimary();
            /* FunctionUpdater(() =>
             {
                 Player.instance.stats.Heal((item as Drink).healingAmount);
             });*/

            FunctionTimer a = FunctionTimer.Create(() =>
            {
                Player.instance.stats.Heal((item as Drink).healingAmount);
            }, timer);     
        }
    }
}
