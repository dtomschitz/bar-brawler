using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : EntityStats
{
    public Image healthBar;

    public override void Damage(float damage) 
    {
        base.Damage(damage);
        healthBar.fillAmount = CurrentHealth / maxHealth;
    }
}
