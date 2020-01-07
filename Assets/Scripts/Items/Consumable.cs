﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Equippable
{
    private Drink drink;

    void Start()
    {
        if (!(item is Drink))
        {
            throw new UnityException("Item is not of the type Drink");
        }

        drink = (item as Drink);
    }

    public override void OnInteractPrimary()
    {
        PlayerStats stats = Player.instance.stats;
        if (stats != null)
        {
            if (stats.HasFullLife) return;

            Player.instance.inventory.UseItem(item);
            stats.Heal(drink.healingAmount);
        }
    }
}