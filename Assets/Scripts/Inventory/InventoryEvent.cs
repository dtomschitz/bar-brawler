using System;

public class InventoryEvent : EventArgs
{
    public EquippableItem item;

    public InventoryEvent(EquippableItem item)
    {
        this.item = item;
    }
}
