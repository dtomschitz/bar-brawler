namespace Shop
{
    public class Munition : ShopItem
    {
        public override void OnItemBought()
        {
            base.OnItemBought();
            //Player.instance.inventory.AddAmmunition((item as Munition))
        }
    }

}