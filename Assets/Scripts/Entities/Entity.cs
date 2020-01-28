using UnityEngine;

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

    public virtual void Start()
    {
        if (stats != null)
        {
            stats.OnTakeDamage += OnTakeDamage;
            stats.OnDeath += OnDeath;
        }
    }

    public virtual void OnHit(Entity offender)
    {
        if (stats.IsDead) return;
        offender.combat.Attack(stats);
    }

    public virtual void OnTakeDamage(float damage)
    {
    }

    public virtual void OnDeath()
    {
    }
}
