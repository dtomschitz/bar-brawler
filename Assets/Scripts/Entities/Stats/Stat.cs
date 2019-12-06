using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public int baseValue;
    public List<int> modifiers = new List<int>();

    public void AddModifier(int modifier)
    {
        if (modifier != 0) modifiers.Add(modifier);
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0) modifiers.Remove(modifier);
    }

    public int GetValue
    {
        get
        {
            int value = baseValue;
            modifiers.ForEach(modifier => value += modifier);
            return value;
        }
    }
}
