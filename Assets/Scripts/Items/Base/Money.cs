using UnityEngine;

namespace Items
{
    /// <summary>
    /// Class <c>Money</c> is used to give the item an specific amount of money
    /// which the player should get if he collects and money from the ground.
    /// </summary>
    [CreateAssetMenu(fileName = "New Money Item", menuName = "Items/Money")]
    public class Money : Item
    {
        public int amount;
    }
}