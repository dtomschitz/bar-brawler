using UnityEngine;

public class EnemyCombat : EntityCombat
{
    private float attackCooldown = 0.0f;

    private bool disabled = false;

    public void OnEnable()
    {
        disabled = false;
    }

    public void OnDisable()
    {
        disabled = true;
    }

    void FixedUpdate()
    {
        if (attackCooldown > 0.0f)
        {
            attackCooldown -= Time.fixedDeltaTime;
        }
    }


    /*public override bool OnAttack()
    {
        if (disabled || IsBlocking || IsStunned || attackCooldown > 0.0f) return false;

        //TODO: attack animation and player attack;

        return true;
    }*/

    public bool IsDisabled
    {
        get { return disabled; }
    }
}
