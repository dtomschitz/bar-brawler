using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityStats))]
public class Enemy : EntityInteraction
{
    public EntityStats stats;
    //public Money money;
    //public GameObject DamagePopup;

    void Start()
    {
        stats = GetComponent<EntityStats>();
        stats.OnHealthIsZero += Death;
    }

    public override void Interact()
    {
        if (stats.IsDead) return;

        EntityCombat combat = Player.instance.combat;
        combat.Attack(stats);

        //if (DamagePopup) ShowDamagePopup();
    }

   /* void ShowDamagePopup()
    {
        var popup = Instantiate(DamagePopup, transform.position, Quaternion.identity, transform);
        popup.GetComponent<TextMesh>().text = stats.CurrentHealth.ToString();
    }*/

    void Death()
    {
        //Instantiate(money, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
