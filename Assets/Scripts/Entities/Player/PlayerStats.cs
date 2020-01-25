﻿using Items;

public class PlayerStats : EntityStats
{
    public float manaRegenerationSpeed;

    private EquipmentManager equipment;

    public override void Start()
    {
        base.Start();
        equipment = GetComponent<EquipmentManager>();
        equipment.OnItemEquipped += OnItemEquipped;
    }

    private void OnItemEquipped(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null && newItem is Weapon)
        {
            damage = (newItem as Weapon).damage;
        }

        /*if (oldItem != null && oldItem is Weapon)
        {
            damage.RemoveModifier((oldItem as Weapon).damage);
        }*/
    }
}
