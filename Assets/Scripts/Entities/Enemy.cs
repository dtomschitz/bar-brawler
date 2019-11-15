using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : EntityInteraction
{
    public CharacterStats stats;
    public GameObject DamagePopup;

    void Start()
    {
        stats = GetComponent<CharacterStats>();
        stats.OnHealthIsZero += Death;
    }

    public override void Interact()
    {
        if (stats.isDead()) return;

        EntityCombat combat = Player.instace.combat;
        combat.Attack(stats);

        if (DamagePopup) ShowDamagePopup();
    }

    void ShowDamagePopup()
    {
        var popup = Instantiate(DamagePopup, transform.position, Quaternion.identity, transform);
        popup.GetComponent<TextMesh>().text = stats.currentHealth.ToString();
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
