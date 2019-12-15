using System;


public class EquipmentEvent : EventArgs
{
    public Equipment newItem;
    public Equipment oldItem;

    public EquipmentEvent(Equipment newItem, Equipment oldItem)
    {
        this.newItem = newItem;
        this.oldItem = oldItem;
    }
}
