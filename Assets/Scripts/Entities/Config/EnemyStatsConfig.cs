using UnityEngine;

/// <summary>
/// Class <c>EnemyStatsConfig</c> is used to define the final paramters such as
/// the min and max health and the damage which the enemy could deal. If the
/// config gets loaded into an Enemy a random value between the min and the max
/// health will be picked.
/// But all values could be eventually be overridden by the <see cref="RandomItem"/>
/// the enemy equipped.
/// </summary>
[CreateAssetMenu(fileName = "New Stats Config", menuName = "Configs/Stats Config")]
public class EnemyStatsConfig : ScriptableObject
{
    public float maxHealth;
    public float minHealth;
    public float damage;
}
