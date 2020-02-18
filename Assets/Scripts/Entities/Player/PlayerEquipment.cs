using System;
using Items;

public class PlayerEquipment : EntityEquipment
{
    public Item[] defaultItems;

    private Inventory inventory;
    private Hotbar hotbar;

    protected override void Start()
    {
        base.Start();

        inventory = Player.instance.inventory;
        if (inventory == null) throw new ArgumentException("Player inventory cannot be null");
        inventory.OnItemRemoved += OnItemRemoved;

        hotbar = FindObjectOfType<Hotbar>();
        if (hotbar == null) throw new ArgumentException("Hotbar cannot be null");
        hotbar.OnItemSelected += EquipItem;
    }

    public void EquipFirstItem()
    {
        if (defaultItems.Length != 0)
        {
            EquipItem(defaultItems[0] as Equipment);
        }
    }

    private void OnItemRemoved(object sender, InventoryEvent e)
    {
        if (e.item == currentEquipment) Unequip();
    }
}