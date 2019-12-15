using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : Equippable
{
    public float attackRate = 20f;
    private float attackCooldown = 0f;

    private EntityCombat combat;
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

    public override void OnInteract()
    {
        if (attackCooldown <= 0f)
        {
            attackCooldown = 1f / attackRate;
            StartCoroutine(AttackRoutine());
            animator.OnAttack();
        }
    }

    private IEnumerator AttackRoutine()
    {
        combat.state = CombatState.ATTACKING;
        yield return new WaitForSeconds(1f);
        combat.state = CombatState.IDLE;
    }
}
