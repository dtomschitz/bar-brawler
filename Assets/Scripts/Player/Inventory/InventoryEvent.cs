using System;

public class InventoryEvent : EventArgs
{
    public Equippable item;

    public InventoryEvent(Equippable item)
    {
        this.item = item;
    }
}
