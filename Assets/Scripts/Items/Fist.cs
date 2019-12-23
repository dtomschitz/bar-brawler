using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : Equippable
{
    public float attackRate = 20f;
    public int manaBlockingCost = 20;
    private float attackCooldown = 0f;

    private PlayerCombat combat;
    private PlayerAnimator animator;

    void Start()
    {
        combat = Player.instance.combat;
        animator = Player.instance.animator;
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public override void OnInteractPrimary()
    {
        if (attackCooldown <= 0f)
        {
            attackCooldown = 1f / attackRate;
            StartCoroutine(AttackRoutine());
            animator.OnAttack();
        }
    }

    public override void OnInteractSecondary()
    {
        base.OnInteractSecondary();
        if (combat.CurrentMana >= manaBlockingCost)
        {
            combat.UseMana(manaBlockingCost);
            StartCoroutine(BlockingRoutine());
        }
    }

    private IEnumerator AttackRoutine()
    {
        combat.state = CombatState.ATTACKING;
        yield return new WaitForSeconds(1f);
        combat.state = CombatState.IDLE;
    }

    private IEnumerator BlockingRoutine()
    {
        combat.state = CombatState.BLOCKING;
        yield return new WaitForSeconds(2f);
        combat.state = CombatState.IDLE;
    }
}
