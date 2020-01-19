using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
    public class Weapon : Equipment
    {
        //public Items weaponType;
        public int damageModifier;
    }

}