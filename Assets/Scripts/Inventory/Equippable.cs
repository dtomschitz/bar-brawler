using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : Item
{
    public SkinnedMeshRenderer prefab;

    public override void Use()
    {
        EquipmentManager.instance.Equip(this);
    }
}
