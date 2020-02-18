using System.Collections.Generic;
using Items;

/// <summary>
/// Class <c>InventorySlot</c> is used to store a set ammount of items of the same
/// type. Each slot has it unique id which is used in the <see cref="Hotbar"/> class.
/// </summary>
public class InventorySlot
{
    private int id = 0;
    private Stack<Item> stack;

    public InventorySlot(int id)
    {
        this.id = id;
        stack = new Stack<Item>();
    }

    /// <summary>
    /// This method adds the given item to the slot and sets a reference in the item.
    /// </summary>
    /// <param name="item">The item which should be added.</param>
    public void Add(Item item)
    {
        item.slot = this;
        stack.Push(item);
    }

    /// <summary>
    /// This method removes the given item from the slot.
    /// </summary>
    /// <param name="item">The item which should be removed.</param>
    public bool Remove(Item item)
    {
        if (IsEmpty) return false;

        Item first = stack.Peek();
        if (first.name == item.name)
        {
            stack.Pop();
            return true;
        }
        return false;
    }

    /// <summary>
    /// This method determines whether the slot has space for more items or not
    /// based on the set maximum stack size.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>True if the slot has space for more items; otherwise false.</returns>
    public bool IsStackable(Item item)
    {
        if (IsEmpty || !item.isStackable) return false;

        Item first = stack.Peek();
        if (first.name == item.name && stack.Count < item.maxStackSize) return true;

        return false;
    }

    /// <summary>
    /// Returns the first item of the slot.
    /// </summary>
    public Item FirstItem
    {
        get
        {
            if (IsEmpty) return null;
            return stack.Peek();
        }
    }

    /// <summary>
    /// Returns true if the inventory is full; otherwise false.
    /// </summary>
    public bool IsFull
    {
        get { return FirstItem != null && Count == FirstItem.maxStackSize; }
    }

    /// <summary>
    /// Returns true if the inventory is emtpy; otherwise false.
    /// </summary>
    public bool IsEmpty
    {
        get { return Count == 0; }
    }

    /// <summary>
    /// Returns the ammount of items the slot keeps.
    /// </summary>
    public int Count
    {
        get { return stack.Count; }
    }

    /// <summary>
    /// Returns the id of the slot which is used in the <see cref="Hotbar"/> class.
    /// </summary>
    public int Id
    {
        get { return id; }
    }
}
