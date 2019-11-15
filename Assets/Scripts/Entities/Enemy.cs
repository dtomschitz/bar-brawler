﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    public CharacterStats stats;

    void Start()
    {
        stats = GetComponent<CharacterStats>();
        stats.OnHealthIsZero += Die;
    }

    public override void Interact()
    {
        EntityCombat combat = Player.instace.combat;
        Debug.Log(combat);
        combat.Attack(stats);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}