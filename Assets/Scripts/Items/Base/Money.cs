using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Money Item", menuName = "Items/Money")]
    public class Money : Item
    {
        public int amount;

        public override void OnCollection()
        {
            base.OnCollection();
            Player.instance.AddMoney(amount);
        }
    }
}