using Utils;

namespace Items
{
    public class Feuersaft : Consumable
    {
        public override void OnPrimary()
        {
            base.OnPrimary();
            StartDrinking();
        }
    }
}
