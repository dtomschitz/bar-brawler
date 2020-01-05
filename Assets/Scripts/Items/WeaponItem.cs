using System;
using System.Collections;
using UnityEngine;

public class WeaponItem : Equippable
{
    public float primaryAttackRate = 20f;
    public float secondaryAttackRate = 20f;

    public float primaryManaRequired = 0f;
    public float secondaryManaRequired = 0f;

    private float primaryCooldown = 0f;
    private float secondaryCooldown = 0f;

    private Coroutine primaryRoutine;
    private Coroutine secondaryRoutine;

    protected PlayerCombat combat;
    protected PlayerAnimator animator;

    void Start()
    {
        combat = Player.instance.combat;
        animator = Player.instance.animator;
    }

    void Update()
    {
        primaryCooldown -= Time.deltaTime;
        secondaryCooldown -= Time.deltaTime;
    }

    public override void OnInteractPrimary()
    {
        base.OnInteractPrimary();
        Cooldown(primaryCooldown, primaryManaRequired, combat.CurrentMana,
            () =>
            {
                primaryCooldown = 1f / primaryAttackRate;
                OnPrimaryAccomplished();
            },
            () => combat.state = CombatState.IDLE
        );
        

        /*if (primaryCooldown <= 0f)
        {
            primaryCooldown = 1f / primaryAttackRate;
            OnPrimaryAccomplished();
        }
        else
        {
            combat.state = CombatState.IDLE;
        }*/
    }

    public override void OnInteractSecondary()
    {
        base.OnInteractSecondary();
        /*if (secondaryCooldown <= 0f)
        {
            secondaryCooldown = 1f / secondaryAttackRate;
            OnSecondaryAccomplished();
        }*/
        Cooldown(secondaryCooldown, secondaryManaRequired, combat.CurrentMana,
            () =>
            {
                secondaryCooldown = 1f / secondaryAttackRate;
                OnSecondaryAccomplished();
            },
            () => {}
        );
    }

    public virtual void OnPrimaryAccomplished()
    {
    }

    public virtual void OnSecondaryAccomplished()
    {
    }

    public virtual void StartPrimaryRoutine(IEnumerator routine)
    {
        if (primaryRoutine != null)
        {
            StopCoroutine(primaryRoutine);
            primaryRoutine = null;
        }

        primaryRoutine = StartCoroutine(routine);
    }

    public virtual void StartSecondaryRoutine(IEnumerator routine)
    {
        if (secondaryRoutine != null)
        {
            StopCoroutine(secondaryRoutine);
            secondaryRoutine = null;
        }

        secondaryRoutine = StartCoroutine(routine);
    }

    private void Cooldown(float cooldown, float requiredMana, float currentMana, Action trueCallback, Action falseCallback)
    {
        if (cooldown <= 0f && currentMana >= requiredMana) trueCallback();
        else falseCallback();
    }
}
