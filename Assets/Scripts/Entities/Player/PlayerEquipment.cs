public class PlayerEquipment : EntityEquipment
{
    private Inventory inventory;
    private Hotbar hotbar;

    protected override void Start()
    {
        base.Start();

        inventory = Player.instance.inventory;
        if (inventory != null) inventory.OnItemRemoved += OnItemRemoved;

        hotbar = FindObjectOfType<Hotbar>();
        if (hotbar != null) hotbar.OnItemSelected += EquipItem;
    }

    private void OnItemRemoved(object sender, InventoryEvent e)
    {
        if (e.item == currentEquipment)
        {
            Unequip();
        }
    }
}