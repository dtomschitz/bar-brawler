using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot
{
    private int id = 0;
    private Stack<Item> stack = new Stack<Item>();

    public Slot(int id)
    {
        this.id = id;
    }

    public void Add(Item item)
    {
        item.slot = this;
        stack.Push(item);
    }

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

    public bool IsStackable(Item item)
    {
        if (IsEmpty) return false;

        Item first = stack.Peek();
        if (item.isStackable && first.name == item.name) return true;

        return false;
    }

    public Item FirstItem
    {
        get
        {
            if (IsEmpty) return null;
            return stack.Peek();
        }
    }

    public bool IsEmpty
    {
        get { return Count == 0; }
    }

    public int Count
    {
        get { return stack.Count; }
    }

    public int Id
    {
        get { return id; }
    }
}
