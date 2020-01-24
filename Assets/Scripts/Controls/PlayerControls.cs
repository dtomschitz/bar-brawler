using System;
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

    public event Action OnHotbarOneBack;
    public event Action OnHotbarOneForward;

    private Camera mainCamera;
    private PlayerInputActions inputActions;
    private PlayerAnimator playerAnimator;
    private CharacterController character;
    private EquipmentManager equipment;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        inputActions.PlayerControls.Rotation.performed += ctx => lookPosition = ctx.ReadValue<Vector2>();

        inputActions.PlayerControls.Primary.started += UsePrimary;
        inputActions.PlayerControls.Secondary.started += UseSecondary;
        inputActions.PlayerControls.UseItem.started += UseItem;
        inputActions.PlayerControls.Interact.performed += InteractWithBarkeeper;

        inputActions.PlayerControls.HotbarOneForward.performed += HotbarForward;
        inputActions.PlayerControls.HotbarOneBack.performed += HotbarBack;
        inputActions.PlayerControls.Pause.performed += PauseGame;
    }

    void Start()
    {
        mainCamera = Camera.main;
        character = GetComponent<CharacterController>();
        playerAnimator = GetComponent<PlayerAnimator>();
        equipment = GetComponent<EquipmentManager>();
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void FixedUpdate()
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
        }    
    }

    public void UsePrimary(CallbackContext ctx) => equipment.UsePrimary();
    public void UseSecondary(CallbackContext ctx) => equipment.UseSecondary();
    public void UseItem(CallbackContext ctx) => equipment.UseConsumable();

    public void HotbarForward(CallbackContext ctx) => OnHotbarOneForward?.Invoke();
    public void HotbarBack(CallbackContext ctx) => OnHotbarOneBack?.Invoke();
    public void PauseGame(CallbackContext ctx)
    {
        GameState.instance.SetState(State.GAME_PAUSED);
    }

    public void InteractWithBarkeeper(CallbackContext ctx)
    {
        if (!WaveSpawner.instance.IsWaveRunning && GameState.instance.state != State.GAME_PAUSED || GameState.instance.state != State.GAME_OVER)
        {

        }
    }

    private void StopPlayerMovement()
    {
        MovePlayer(Vector3.zero);
    }

    private void MovePlayer(Vector3 desiredDirection)
    {
        movement.Set(desiredDirection.x, movement.y, desiredDirection.z);
        movement = movement * speed * Time.deltaTime;

        character.Move(movement);

        movement.y += (Physics.gravity.y * gravityScale * Time.deltaTime);

        AnimatePlayerMovement(desiredDirection);
    }

    private void TurnPlayer()
    {
        Vector2 input = lookPosition;
        Vector3 lookDirection = new Vector3(input.x, 0, input.y);

        Vector3 lookRotation = mainCamera.transform.TransformDirection(lookDirection);
        lookRotation = Vector3.ProjectOnPlane(lookRotation, Vector3.up);

        if (lookRotation != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(lookRotation);
            playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, newRotation, Time.deltaTime * 10f);
        }
    }

    private void AnimatePlayerMovement(Vector3 desiredDirection)
    {
        if (!playerAnimator) return;

        Vector3 movement = new Vector3(desiredDirection.x, 0f, desiredDirection.z);
        float forward = Vector3.Dot(movement, playerModel.transform.forward);
        float strafe = Vector3.Dot(movement, playerModel.transform.right);

        playerAnimator.SetForward(forward);
        playerAnimator.SetStrafe(strafe);
    }

    public bool IsMovementEnabled
    {
        get { return isMovementEnebaled; }
        set 
        {
            if (isMovementEnebaled == value) return;
            isMovementEnebaled = value;
            if (!value) StopPlayerMovement();
        }
    }

}
