using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : EntityStats
{
    private EquipmentManager equipment;

    public override void Start()
    {
        base.Start();
        equipment = GetComponent<EquipmentManager>();
        equipment.OnItemEquipped += OnItemEquipped;
    }

    private void OnItemEquipped(object sender, EquipmentEvent e)
    {

        if (e.newItem != null && e.newItem is Weapon)
        {
            damage.AddModifier((e.newItem as Weapon).damageModifier);
        }

        if (e.oldItem != null && e.oldItem is Weapon)
        {
            damage.RemoveModifier((e.oldItem as Weapon).damageModifier);
        }

        //TODO: Update damage modifier
    }
}
