using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEvent : EventArgs
{
    public EquippableItem item;

    public InventoryEvent(EquippableItem item)
    {
        this.item = item;
    }
}
