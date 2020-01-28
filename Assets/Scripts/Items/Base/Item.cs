using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
    public class Item : ScriptableObject
    {
        [Header("Data")]
        new public string name;
        public Sprite icon;
        public ItemKind kind;

        [Header("Inventory")]
        public bool addToInventory = true;
        public bool isStackable = true;
        public int maxStackSize = 1;
        public InventorySlot slot;

        public virtual void OnCollection()
        {
            Player.instance.inventory.AddItem(this);
        }
    }

    public enum ItemKind
    {
        Consumable,
        Weapon
    }

    public enum ItemType
    {
        Fist,
        Revolver,
        Bottle,
        Knife,
        Whiskey,
        Beer,
        Feuersaft
    }
}