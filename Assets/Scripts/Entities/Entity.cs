using System;
using UnityEngine;
using Items;

[RequireComponent(typeof(EntityEquipment))]
[RequireComponent(typeof(EntityStats))]
[RequireComponent(typeof(EntityCombat))]
[RequireComponent(typeof(EntityAnimator))]
public class Entity : MonoBehaviour
{
    [Header("Entity Base")]
    public EntityStats stats;
    public EntityCombat combat;
    public EntityAnimator animator;
    public EntityEquipment equipment;

    protected virtual void Start()
    {
        if (stats == null) throw new ArgumentException("Entity stats class cannot be null");
        if (combat == null) throw new ArgumentException("Entity combat class cannot be null!");
        if (animator == null) throw new ArgumentException("Entiy animator class cannot be null!");
        if (equipment == null) throw new ArgumentException("Entity equipment class cannot be null!");

        stats.OnDamaged += OnDamaged;
        stats.OnDeath += OnDeath;
    }

    public virtual void OnHit(Entity offender, Equipment item)
    {
        if (stats.IsDead) return;
        
        offender.combat.Attack(stats, item);
        combat.SetState(CombatState.Stunned);

        animator.OnHit(0);
    }

    public virtual void OnDamaged(float damage, Equipment item)
    {
        FindObjectOfType<AudioManager>().Play("FightReaction");
    }

    public virtual void OnDeath()
    {
    }
}
