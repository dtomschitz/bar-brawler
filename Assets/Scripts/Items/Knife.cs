using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : WeaponItem
{
    public float bleedOutDamage = 2f;
    public float bleedOutTime = 10f;

    public override void OnPrimaryAccomplished()
    {
        combat.state = CombatState.ATTACKING;
        StartPrimaryRoutine(PrimaryRoutine());
        animator.OnPrimary();
    }

    public override void OnHit(Enemy enemy)
    {
        base.OnHit(enemy);
        StartCoroutine(KnifeBleedOut(enemy));
       
    }

    private IEnumerator KnifeBleedOut(Enemy enemy)
    {
        var pastTime = 0f;
        while (pastTime < bleedOutTime)
        {
            Debug.Log("Knife");

            enemy.Stats.TakeDamage(bleedOutDamage);
            pastTime++;
            yield return new WaitForSeconds(1f);
        }
    }
}
