using UnityEngine;

public class PlayerAnimator : EntityAnimator
{
    //public WeaponAnimation[] weaponAnimations;
    //WeaponAnimation currentWeaponAnimation;

    protected override void Start()
    {
        base.Start();
    }

    /*void Update()
    {
        float h = movementInput.x;
        float v = movementInput.y;

        animator.SetFloat("VelocityX", h);
        animator.SetFloat("VelocityY", v);
        //animator.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }*/

    public void SetForward(float forward)
    {
        animator.SetFloat("Forward", forward);
    }


    public void SetStrafe(float strafe)
    {
        animator.SetFloat("Strafe", strafe);
    }

    public override void OnPrimary()
    {
        base.OnPrimary();
    }
}