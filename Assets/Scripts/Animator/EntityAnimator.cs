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
        animator.SetTrigger("attack");
    }

    public virtual void OnSecondary()
    {
        animator.SetTrigger("secondaryAttack");
    }

    public virtual void OnDeath()
    {
        animator.SetTrigger("Death");
    }
    
    public void SetItem(Items.ItemType type)
    {
        int currentWeaponType = animator.GetInteger("item");
        int newWeaponType = (int)type;

        if (currentWeaponType == newWeaponType) return;

        animator.SetInteger("item", newWeaponType);
    }
}