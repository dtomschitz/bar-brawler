using System;
using UnityEngine;
using Items;

[CreateAssetMenu(fileName = "New Enemy Config", menuName = "Configs/Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    public StatsConfig stats;
    public CombatConfig combat;

    [Header("Money")]
    public int[] moneyDrops;

    [Header("Equipment")]
    public RandomItem[] items;
}

[Serializable]
public class RandomItem
{
    public int percentage;
    public Equipment item;
    public int damageOverride;
}