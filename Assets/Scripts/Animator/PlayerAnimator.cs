using UnityEngine;

public class PlayerAnimator : EntityAnimator
{
    //public WeaponAnimation[] weaponAnimations;
    //WeaponAnimation currentWeaponAnimation;

    private PlayerInputActions inputActions;
    private Vector2 movementInput;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        float h = movementInput.x;
        float v = movementInput.y;

        animator.SetFloat("VelocityX", h);
        animator.SetFloat("VelocityY", v);
        //animator.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }

    public override void OnPrimary()
    {
        base.OnPrimary();
    }
}