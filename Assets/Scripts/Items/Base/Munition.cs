using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Munition", menuName = "Items/Munition")]
    public class Munition : Item
    {
        public int amount;
    }
}