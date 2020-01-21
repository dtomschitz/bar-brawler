using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float jumpForce;
    public float gravityScale;
    public float rotateSpeed;
    public float cameraRayLength = 100f;
    public bool IsMovementEnabled { get; set; } = true;

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
    }

    void Start()
    {
        mainCamera = Camera.main;
        character = GetComponent<CharacterController>();
        playerAnimator = GetComponent<PlayerAnimator>();
        equipment = GetComponent<EquipmentManager>();
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
        HandleInput();
    }

    void FixedUpdate()
    {
        if (IsMovementEnabled)
        {
            //float horizontalh = Input.GetAxisRaw("Horizontal");
            //float vertical = Input.GetAxisRaw("Vertical");
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

    private void MovePlayer(Vector3 desiredDirection)
    {
        movement.Set(desiredDirection.x, movement.y, desiredDirection.z);
        movement = movement * speed * Time.deltaTime;

        character.Move(movement);

        movement.y += (Physics.gravity.y * gravityScale * Time.deltaTime);

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

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (equipment.CurrentItem != null)
            {
                equipment.CurrentItem.OnInteractPrimary();
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (equipment.CurrentItem != null)
            {
                equipment.CurrentItem.OnInteractSecondary();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!WaveSpawner.instance.IsWaveRunning)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRange, barkeeperMask);
                foreach (Collider collider in colliders)
                {
                    Interactable interactable = collider.GetComponent<Interactable>();
                    if (interactable != null) interactable.Interact();
                }
                return;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionRange == 0f) return;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
