using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    new public string name;
    public Sprite icon;
    public ItemType type;
    public bool addToInventory = true;

    public Slot slot;

    public virtual void OnInteract()
    {
    }
    
}

public enum ItemType
{
    Consumable,
    Weapon
}

public enum WeaponType
{
    Fist,
    Revolver,
    Bottle
}
