using Utils;

namespace Items
{
    public class Beer : Consumable
    {
        public override void OnPrimary()
        {
            base.OnPrimary();
            StartDrinking();
        }
    }
}
