using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : Weapon
{
    private EntityCombat combat;
    private PlayerAnimator animator;

    void Start()
    {
        combat = Player.instance.combat;
        animator = Player.instance.animator;
    }

    public override void OnInteract()
    {
        StartCoroutine(AttackRoutine());
        animator.OnAttack();
    }

    private IEnumerator AttackRoutine()
    {
        combat.state = CombatState.ATTACKING;
        yield return new WaitForSeconds(1f);
        combat.state = CombatState.IDLE;
    }
}
