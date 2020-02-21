using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

/// <summary>
/// This class <c>PlayerControls</c> is used to control the player movement such
/// as moving, rotatining, jumping and triggering the primary and secondary action.
/// In order to move the player the <see cref="CharacterController"/> is used under
/// the hut.
/// </summary>
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

    /// <summary>
    /// Subscribes to the set <see cref="PlayerInputActions"/> controlls. 
    /// </summary>
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

    /// <summary>
    /// Updates the player movement direction and caluulates the new desired
    /// direction. Then the methods <see cref="MovePlayer(Vector3)"/>,
    /// <see cref="RotatePlayer"/> and <see cref="AnimatePlayerMovement(Vector3)"/>
    /// gets called with the new calculated parameters.
    /// </summary>
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
            RotatePlayer();
            AnimatePlayerMovement(desiredDirection);
        }
    }

    /// <summary>
    /// This method is used to subscribe to the specific <see cref="PlayerInputActions"/>
    /// method and gets called if the user pressed the button which should trigger
    /// the primary action. If the game state is currently set to
    /// <see cref="GameStateType.TargetAcquisition"/> the request will get rejected.
    /// </summary>
    /// <param name="ctx"></param>
    public void UsePrimary(CallbackContext ctx)
    {
        if (GameState.instance.IsInTargetAcquisition) return;
        equipment.UsePrimary();
    }

    /// <summary>
    /// This method is used to subscribe to the specific <see cref="PlayerInputActions"/>
    /// method and gets called if the user pressed the button which should trigger
    /// the secondary action. If the game state is currently set to
    /// <see cref="GameStateType.TargetAcquisition"/> the request will get rejected.
    /// </summary>
    /// <param name="ctx"></param>
    public void UseSecondary(CallbackContext ctx)
    {
        if (GameState.instance.IsInTargetAcquisition) return;
        equipment.UseSecondary();
    }

    /// <summary>
    /// This method is used to subscribe to the specific <see cref="PlayerInputActions"/>
    /// method and gets called if the user pressed the button which should trigger
    /// action to use an item. If the game state is currently set to
    /// <see cref="GameStateType.TargetAcquisition"/> the request will get rejected.
    /// </summary>
    /// <param name="ctx"></param>
    public void UseItem(CallbackContext ctx)
    {
        if (GameState.instance.IsInTargetAcquisition) return;
        equipment.UseConsumable();
    }

    /// <summary>
    /// This method sets game state to <see cref="GameStateType.GamePaused"/> and
    /// and will thereby pause the game.
    /// </summary>
    /// <param name="ctx"></param>
    public void PauseGame(CallbackContext ctx)
    {
        GameState.instance.SetState(GameStateType.GamePaused);
    }

    /// <summary>
    /// This method stops the player by setting the desired movement direction to
    /// <see cref="Vector3.zero"/>. In addition the currently played animation
    /// will blend to the idle animation by setting the forward and strafe velocity
    /// to zero.
    /// </summary>
    private void StopPlayerMovement()
    {
        MovePlayer(Vector3.zero);
        playerAnimator.Move(0f, 0f);
    }

    /// <summary>
    /// This method moves the player to the given desired direction by multiplying
    /// it with the set speed and the <see cref="Time.deltaTime"/>. In order to
    /// move the whole game object the class <see cref="CharacterController"/>
    /// gets used as mentioned. Furthermore the method calculcates the movement
    /// on the y-axis.
    /// </summary>
    /// <param name="desiredDirection">The calculated deseired movement direction.</param>
    private void MovePlayer(Vector3 desiredDirection)
    {
        movement.Set(desiredDirection.x, movement.y, desiredDirection.z);
        movement = movement * speed * Time.deltaTime;

        character.Move(movement);

        movement.y += (Physics.gravity.y * gravityScale * Time.deltaTime * 0.6f);
    }

    /// <summary>
    /// This method is used to rotate the player to a desired location.
    /// If the game state is for example currently set to <see cref="GameStateType.TargetAcquisition"/>
    /// and the user has selected an enemy, the player will automaticly rotate
    /// towards the enemy. This should improve and simplify the attacking behavior.
    /// If the aforementioned case has not occurred the player rotates based on
    /// the game pad input respectively the current camera looking direction.
    /// </summary> 
    private void RotatePlayer()
    {
        if (GameState.instance.IsInTargetAcquisition && TargetAcquisition.instance.CurrentEnemy != null)
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

    /// <summary>
    /// This method rotates the player towards the currently selected enemy from
    /// the target acquisition mod.
    /// </summary>
    private void TurnPlayerToEnemy()
    {
        Enemy enemy = TargetAcquisition.instance.CurrentEnemy;

        Vector3 lookDirection = (enemy.transform.position - playerModel.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0, lookDirection.z));
        playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, lookRotation, Time.deltaTime * 10000f);
    }

    /// <summary>
    /// This method sets the movement forward and strafe velocity in order to trigger
    /// the specifc animations. 
    /// </summary>
    /// <param name="desiredDirection"></param>
    private void AnimatePlayerMovement(Vector3 desiredDirection)
    {
        if (!playerAnimator) return;

        Vector3 movement = new Vector3(desiredDirection.x, 0f, desiredDirection.z);
        float forward = Vector3.Dot(movement, playerModel.transform.forward);
        float strafe = Vector3.Dot(movement, playerModel.transform.right);

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
            }
            else
            {
                inputActions.Enable();
            }
        }
    }
}
