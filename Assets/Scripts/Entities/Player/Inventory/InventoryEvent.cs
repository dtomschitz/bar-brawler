using System;
using Items;

public class InventoryEvent : EventArgs
{
    public Item item;

    public InventoryEvent(Item item)
    {
        this.item = item;
    }
}
