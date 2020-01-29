using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stats Config", menuName = "Configs/Stats Config")]
public class StatsConfig : ScriptableObject
{
    public float maxHealth;
    public float damage;
}
