using UnityEngine;

namespace Items
{
    /// <summary>
    /// Class <c>Munition</c> is used to store an specific amount of ammunition
    /// so the player can buy it in the shop.
    /// </summary>
    [CreateAssetMenu(fileName = "New Munition", menuName = "Items/Munition")]
    public class Munition : Item
    {
        public int amount;
    }
}