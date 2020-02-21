using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>PlayerCombat</c> extends the <c>EntityCombat</c> class and override
/// specifc methods. Additionally new methods are implemented to handle the
/// attacking on the player.
/// </summary>
public class PlayerCombat : EntityCombat
{
    public int simultaneousAttackers = 2;
    private List<GameObject> attackers;

    protected override void Start()
    {
        base.Start();

        attackers = new List<GameObject>();
        CurrentMana = maxMana;
    }

    /// <summary>
    /// This method gets called if an enemy tries to attack the player. If the
    /// set limit of simultaneous attackers is currently not reached and is not
    /// already attacking the enemy will get the access.
    /// </summary>
    /// <param name="enemy">The enemy who made the request</param>
    public void OnRequestAttack(GameObject enemy)
    {
        attackers.RemoveAll(attacker => attacker == null);

        if (attackers.Count < simultaneousAttackers)
        {
            if (!attackers.Contains(enemy)) attackers.Add(enemy);
            enemy.SendMessage("OnAllowAttack", gameObject);
        }
    }

    /// <summary>
    /// This method gets called if the attacking enemy is either dead or is no
    /// longer attacking the player. In order to free the space for new attacking
    /// requests the given enemy will be removed from the attacker list.
    /// </summary>
    /// <param name="enemy">The enemy who attacked the player</param>
    public void OnCancelAttack(GameObject enemy) => attackers.Remove(enemy);

    private void OnDrawGizmos()
    {
        if (attackers != null)
        {
            foreach (GameObject attacker in attackers)
            {
                if (attacker != null)
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawWireSphere(attacker.transform.position, 1.0f);
                }
            }
        }
    }
}