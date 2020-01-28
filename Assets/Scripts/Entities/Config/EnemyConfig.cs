using UnityEngine;
using Items;
using System;

[CreateAssetMenu(fileName = "New Enemy Config", menuName = "Configs/Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    public StatsConfig stats;
    public CombatConfig combat;

    [Header("Equipment")]
    public EquipmentChance[] items;
}

[Serializable]
public class EquipmentChance
{
    public Equipment item;
    public float percentage;
}