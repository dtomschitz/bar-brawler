using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerControls : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float jumpForce;
    public float gravityScale;
    public float rotateSpeed;
    public float cameraRayLength = 100f;
    private bool isMovementEnebaled = true;

    private Vector2 movementInput;
    private Vector2 lookPosition;
    private Vector3 inputDirection;
    private Vector3 movement;

    [Header("Interaction")]
    public float interactionRange;
    public LayerMask enemyMask;
    public LayerMask barkeeperMask;
    public LayerMask groundMask;

    [Header("Model")]
    public GameObject playerModel;
    public Transform pivot;

    public PlayerInputActions inputActions;

    private Camera mainCamera;
    private PlayerAnimator playerAnimator;
    private CharacterController character;
    private PlayerEquipment equipment;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        inputActions.PlayerControls.Rotation.performed += ctx => lookPosition = ctx.ReadValue<Vector2>();

        inputActions.PlayerControls.Primary.performed += UsePrimary;
        inputActions.PlayerControls.Secondary.performed += UseSecondary;
        inputActions.PlayerControls.UseItem.performed += UseItem;
        inputActions.PlayerControls.Pause.performed += PauseGame;
    }

    void Start()
    {
        mainCamera = Camera.main;
        character = GetComponent<CharacterController>();
        playerAnimator = GetComponent<PlayerAnimator>();
        equipment = GetComponent<PlayerEquipment>();
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        if (IsMovementEnabled)
        {
            float h = movementInput.x;
            float v = movementInput.y;

            Vector3 input = new Vector3(h, 0f, v);
            inputDirection = Vector3.Lerp(inputDirection, input, Time.deltaTime * 10f);

            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;

            cameraForward.y = 0f;
            cameraRight.y = 0f;

            Vector3 desiredDirection = cameraForward * inputDirection.z + cameraRight * inputDirection.x;

            MovePlayer(desiredDirection);
            TurnPlayer();
            AnimatePlayerMovement(desiredDirection);
        }
    }

    public void UsePrimary(CallbackContext ctx) 
    {
        if (GameState.instance.IsInTargetAcquisition) return;
        equipment.UsePrimary();
    }

    public void UseSecondary(CallbackContext ctx)
    {
        if (GameState.instance.IsInTargetAcquisition) return;
        equipment.UseSecondary();
    }

    public void UseItem(CallbackContext ctx)
    {
        if (GameState.instance.IsInTargetAcquisition) return;
        equipment.UseConsumable();
    }

    public void PauseGame(CallbackContext ctx)
    {
        GameState.instance.SetState(State.GAME_PAUSED);
    }

    private void StopPlayerMovement()
    {
        MovePlayer(Vector3.zero);
        playerAnimator.Move(0f, 0f);
    }

    private void MovePlayer(Vector3 desiredDirection)
    {
        movement.Set(desiredDirection.x, movement.y, desiredDirection.z);
        movement = movement * speed * Time.deltaTime;

        character.Move(movement);

        movement.y += (Physics.gravity.y * gravityScale * Time.deltaTime * 0.6f);
    }

    private void TurnPlayer()
    {
        if (TargetAcquisition.instance.CurrentEnemy != null)
        {
            TurnPlayerToEnemy();
            return;
        }

        Vector2 input = lookPosition;
        Vector3 lookDirection = new Vector3(input.x, 0, input.y);

        Vector3 lookRotation = mainCamera.transform.TransformDirection(lookDirection);
        lookRotation = Vector3.ProjectOnPlane(lookRotation, Vector3.up);

        if (lookRotation != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(lookRotation);
            playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, newRotation, Time.deltaTime * 8f);
        }
    }

    private void TurnPlayerToEnemy()
    {
        Enemy enemy = TargetAcquisition.instance.CurrentEnemy;

        Vector3 lookDirection = (enemy.transform.position - playerModel.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0, lookDirection.z));
        playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, lookRotation, Time.deltaTime * 10000f);
    }

    private void AnimatePlayerMovement(Vector3 desiredDirection)
    {
        if (!playerAnimator) return;

        Vector3 movement = new Vector3(desiredDirection.x, 0f, desiredDirection.z);
        float forward = Vector3.Dot(movement, playerModel.transform.forward);
        float strafe = Vector3.Dot(movement, playerModel.transform.right);

        //playerAnimator.SetForward(forward);
        //playerAnimator.SetStrafe(strafe);
        playerAnimator.Move(forward, strafe);
    }

    public bool IsMovementEnabled
    {
        get { return isMovementEnebaled; }
        set 
        {
            if (isMovementEnebaled == value) return;
            isMovementEnebaled = value;
            if (!value)
            {
                inputActions.Disable();
                StopPlayerMovement();
            } else
            {
                inputActions.Enable();
            }
        }
    }
}
