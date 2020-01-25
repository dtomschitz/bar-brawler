using UnityEngine;
using Items;

public class EntityAnimator : MonoBehaviour
{
    public Animator animator;

    private int currentItem = 0;
    private bool smoothMeleeIdleTransition = false;
    private float currentMeleeIdle;
    private float newMeleeIdle;

    public void LateUpdate()
    {
        if (smoothMeleeIdleTransition)
        {
            currentMeleeIdle = Mathf.Lerp(currentMeleeIdle, newMeleeIdle, Time.deltaTime * 10f);
            animator.SetFloat("MeleeIdle", currentMeleeIdle);

            Debug.Log(currentMeleeIdle);
            if (currentMeleeIdle == newMeleeIdle)
            {
                smoothMeleeIdleTransition = false;
            }
        }
    }

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

    public virtual void OnPunchHit()
    {
        animator.SetTrigger("PunchHit");
    }

    public virtual void OnDeath()
    {
        animator.SetTrigger("Death");
    }
    
    public void SetEquipment(Equipment item)
    {
        int type = (int)item.type;
        if (currentItem == type) return;
        if (item.IsMeleeWeapon) 
        {
            smoothMeleeIdleTransition = true;
            newMeleeIdle = type;
        }

        animator.SetInteger("Item", type);
        currentItem = type;
    }

    public void SetEquipmentAnimation(EquipmentAnimation animation)
    {
        if (animator.GetInteger("ItemAnimation") == animation.index) return;
        animator.SetInteger("ItemAnimation", animation.index);
    }
}