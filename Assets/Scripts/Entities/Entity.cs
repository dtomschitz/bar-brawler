using UnityEngine;

[RequireComponent(typeof(EntityStats))]
[RequireComponent(typeof(EntityCombat))]
[RequireComponent(typeof(EntityAnimator))]
[RequireComponent(typeof(EntityEquipment))]
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

    public virtual void OnHit()
    {
    }

    public virtual void OnTakeDamage(float damage)
    {
    }

    public virtual void OnDeath()
    {
    }
}
