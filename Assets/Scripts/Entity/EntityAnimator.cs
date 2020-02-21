using System;
using UnityEngine;
using Items;

/// <summary>
/// Class <c>EntityAnimator</c> is the base class to handle animations for an entity.
/// </summary>
public class EntityAnimator : MonoBehaviour
{
    public Animator animator;

    protected virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if (animator == null) throw new NullReferenceException("Animator parameter cannot be null");
        GetComponent<EntityEquipment>().OnItemEquipped += OnItemEquipped;
    }

    /// <summary>
    /// Gets called if the entity changed his equipment and will set the correct
    /// animation id.
    /// </summary>
    /// <param name="newItem">The new item.</param>
    /// <param name="oldItem">The old item.</param>
    public void OnItemEquipped(Equipment newItem, Equipment oldItem)
    {
        SetEquipment(newItem);
    }

    /// <summary>
    /// This method will start playing the current primary animation.
    /// </summary>
    public virtual void OnPrimary()
    {
        animator.SetTrigger("Primary");
    }

    /// <summary>
    /// This method will start playing the current secondary animation.
    /// </summary>
    public virtual void OnSecondary()
    {
        animator.SetTrigger("Secondary");
    }


    /// <summary>
    /// This method will start playing the hit animation based on the given id.
    /// </summary>
    /// <param name="id">The animation id</param>
    public virtual void OnHit(int id)
    {
        animator.SetInteger("HitAnimation", id);
        animator.SetTrigger("Hit");
    }

    /// <summary>
    /// This method will start playing the death animation.
    /// </summary>
    public virtual void OnDeath()
    {
        animator.SetTrigger("Death");
    }

    /// <summary>
    /// This method will start playing the victory animation.
    /// </summary>
    public virtual void OnVictory()
    {
        animator.SetTrigger("Victory");
    }

    /// <summary>
    /// This method will start playing the movement animation which will blend
    /// based on the given forward and strafe value.
    /// </summary>
    /// <param name="forward">The forward velocity</param>
    /// <param name="strafe">The strafe velocity</param>
    public virtual void Move(float forward, float strafe)
    {
        SetForward(forward);
        SetStrafe(strafe);
    }

    public void SetIsGrounded(bool isGrounded)
    {
        animator.SetBool("IsGrounded", isGrounded);
    }

    /// <summary>
    /// Sets the forward velocity.
    /// </summary>
    /// <param name="forward">The forward velocity</param>
    public void SetForward(float forward)
    {
        animator.SetFloat("Forward", forward);
    }

    /// <summary>
    /// Sets the strafe velocity.
    /// </summary>
    /// <param name="strafe">The strafe velocity</param>
    private void SetStrafe(float strafe)
    {
        animator.SetFloat("Strafe", strafe);
    }

    /// <summary>
    /// Updates the item animation id based on the given item.
    /// </summary>
    /// <param name="item">The new item.</param>
    public void SetEquipment(Equipment item)
    {
        int currentType = animator.GetInteger("Item");
        int type = (int)item.type;

        if (currentType == type) return;
        if (item.IsMeleeWeapon) 
        {
            animator.SetFloat("MeleeIdle", type);
        }

        animator.SetInteger("Item", type);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="animation"></param>
    public void SetEquipmentAnimation(EquipmentAnimation animation)
    {
        if (animator.GetInteger("ItemAnimation") == animation.index) return;
        animator.SetInteger("ItemAnimation", animation.index);
    }
}