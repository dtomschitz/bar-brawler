using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Neue Waffe", menuName = "Inventory/Weapon")]
public class Weapon : Equippable
{
    public int damageModifier;
    public WeaponType weaponType;
}

public enum WeaponType
{
    FIST,
    BOTTLE,
    REVOLVER
}
