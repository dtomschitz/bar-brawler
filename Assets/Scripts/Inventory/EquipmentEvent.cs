using System;


public class EquipmentEvent : EventArgs
{
    public Equippable newItem;
    public Equippable oldItem;

    public EquipmentEvent(Equippable newItem, Equippable oldItem)
    {
        this.newItem = newItem;
        this.oldItem = oldItem;
    }
}
