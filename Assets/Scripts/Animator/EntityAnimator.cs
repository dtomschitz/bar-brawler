using UnityEngine;
using Items;

public class EntityAnimator : MonoBehaviour
{
    public Animator animator;

    protected virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public virtual void OnPrimary()
    {
        animator.SetTrigger("Primary");
    }

    public virtual void OnSecondary()
    {
        animator.SetTrigger("Secondary");
    }

    public virtual void OnDeath()
    {
        animator.SetTrigger("Death");
    }
    
    public void SetItem(ItemType type)
    {
        int currentWeaponType = animator.GetInteger("Item");
        int newWeaponType = (int)type;

        if (currentWeaponType == newWeaponType) return;

        animator.SetInteger("Item", newWeaponType);
    }
}