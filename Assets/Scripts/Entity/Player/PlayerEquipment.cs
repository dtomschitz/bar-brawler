using System;
using Items;

/// <summary>
/// Class <c>PlayerEquipment</c> extends the <c>EntityEquipment</c> class and
/// adds additional methods.
/// </summary>
public class PlayerEquipment : EntityEquipment
{
    public Item[] defaultItems;

    private PlayerInventory inventory;
    private Hotbar hotbar;

    private bool defaultItemsAdded = false;

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

    void Update()
    {
        if (!defaultItemsAdded)
        {
            AddDefaultItems();
            defaultItemsAdded = true;
        }
    }

    /// <summary>
    /// This method gets triggered if an item got removed from the inventory.
    /// It will then perhaps unequipp the current equipped item
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnItemRemoved(Item item)
    {
        if (item == currentEquipment) Unequip();
    }


    /// <summary>
    /// Adds all default items to the inventory and the hotbar itself. 
    /// </summary>
    private void AddDefaultItems()
    {
        foreach (Item item in defaultItems)
        {
            inventory.AddItem(item);
        }
        EquipFirstItem();
    }

    /// <summary>
    /// This method equips the first item out of the default items the player
    /// received on the game start.
    /// </summary>
    private void EquipFirstItem()
    {
        if (defaultItems.Length != 0)
        {
            EquipItem(defaultItems[0] as Equipment);
        }
    }
}