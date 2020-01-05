using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : WeaponItem
{
    public override void OnPrimaryAccomplished()
    {
        combat.state = CombatState.ATTACKING;
        StartPrimaryRoutine(AttackRoutine());
        animator.OnPrimary();
    }

    public override void OnSecondaryAccomplished()
    {
        combat.state = CombatState.BLOCKING;
        StartSecondaryRoutine(BlockingRoutine());
        animator.OnSecondary();
        combat.UseMana();
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
        yield return new WaitForSeconds(1f);
        combat.state = CombatState.IDLE;
    }

    /*public float attackRate = 20f;
    public float secondaryUseRate = 20f;
    public float manaBlockingCost = 20f;
    private float attackCooldown = 0f;
    private float secondaryCooldown = 0f;

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
        secondaryCooldown -= Time.deltaTime;
    }

    public override void OnInteractPrimary()
    {
        base.OnInteractPrimary();
        if (attackCooldown <= 0f)
        {
            attackCooldown = 1f / attackRate;
            combat.state = CombatState.ATTACKING;
            StartCoroutine(AttackRoutine());
            animator.OnAttack();
        } else
        {
            combat.state = CombatState.IDLE;
        }
    }

    public override void OnInteractSecondary()
    {
        base.OnInteractSecondary();
        if (secondaryCooldown <= 0f && combat.CurrentMana >= manaBlockingCost)
        {
            secondaryCooldown = 1f / secondaryUseRate;
            StartCoroutine(BlockingRoutine());
            combat.UseMana();
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
        yield return new WaitForSeconds(1f);
        combat.state = CombatState.IDLE;
    }*/
}
