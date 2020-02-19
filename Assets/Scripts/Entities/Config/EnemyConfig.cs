using System;
using UnityEngine;
using Items;

/// <summary>
/// Class <c>EnemyConfig</c> is used to provide an place to define all neccessary
/// paramaters for an specific entity type. This includes the <see cref="EnemyStatsConfig"/>,
/// the <see cref="EnemyCombatConfig"/> and the different amounts of money which
/// could be dropped when the enemy dies as well as the random items.
/// </summary>
[CreateAssetMenu(fileName = "New Enemy Config", menuName = "Configs/Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    public EnemyStatsConfig stats;
    public EnemyCombatConfig combat;

    [Header("Money")]
    public int[] moneyDrops;

    [Header("Equipment")]
    public RandomItem[] items;
}

/// <summary>
/// Class <c>RandomItem</c> is used to give an specific item a drop percentage.
/// Additionally the class stores the overridden damage of this item and the
/// health which the enemy should get in the beginning. The health override is
/// possible in order to change the health of an enemy dynamically based on the
/// equipped item.
/// </summary>
[Serializable]
public class RandomItem
{
    public int percentage;
    public Equipment item;
    public int damageOverride;
    public int healthOverride;
}