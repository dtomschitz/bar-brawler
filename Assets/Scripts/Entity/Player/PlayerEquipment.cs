using System;
using Items;

/// <summary>
/// Class <c>PlayerEquipment</c> extends the <c>EntityEquipment</c> class and
/// adds additional methods.
/// </summary>
public class PlayerEquipment : EntityEquipment
{
    public Item[] defaultItems;

    private Inventory inventory;
    private Hotbar hotbar;

    protected override void Start()
    {
        base.Start();

        inventory = Player.instance.inventory;
        if (inventory == null) throw new NullReferenceException("Player inventory cannot be null");
        inventory.OnItemRemoved += OnItemRemoved;

        hotbar = FindObjectOfType<Hotbar>();
        if (hotbar == null) throw new NullReferenceException("Hotbar cannot be null");
        hotbar.OnItemSelected += EquipItem;
    }

    /// <summary>
    /// This method equips the first item out of the default items the player
    /// received on the game start.
    /// </summary>
    public void EquipFirstItem()
    {
        if (defaultItems.Length != 0)
        {
            EquipItem(defaultItems[0] as Equipment);
        }
    }

    /// <summary>
    /// This method gets triggered if an item got removed from the inventory.
    /// It will then perhaps unequipp the current equipped item
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnItemRemoved(object sender, InventoryEvent e)
    {
        if (e.item == currentEquipment) Unequip();
    }
}