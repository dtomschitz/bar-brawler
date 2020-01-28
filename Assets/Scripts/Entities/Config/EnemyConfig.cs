using UnityEngine;
using Items;
using System;

[CreateAssetMenu(fileName = "New Enemy Config", menuName = "Configs/Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    public StatsConfig stats;
    public CombatConfig combat;

    [Header("Equipment")]
    public RandomItem[] items;
}

[Serializable]
public class RandomItem
{
    public Equipment item;
    public int percentage;
}