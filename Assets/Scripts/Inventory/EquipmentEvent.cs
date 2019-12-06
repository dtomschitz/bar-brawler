using System;


public class EquipmentEvent : EventArgs
{
    public EquippableItem newItem;
    public EquippableItem oldItem;

    public EquipmentEvent(EquippableItem newItem, EquippableItem oldItem)
    {
        this.newItem = newItem;
        this.oldItem = oldItem;
    }
}
