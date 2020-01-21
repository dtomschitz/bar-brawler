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
    private Vector3 moveDirection;

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

            Turning();
            Move(h, v);
        }    
    }

    private void Move(float horizontal, float vertical)
    {
        float y = moveDirection.y;

        moveDirection = new Vector3(horizontal, 0f, vertical);
        //moveDirection = horizontal * Camera.main.transform.forward + vertical * Camera.main.transform.right;
       // moveDirection = Quaternion.AngleAxis(Camera.main.transform.rotation.eulerAngles.y, Vector3.up) * moveDirection;
        moveDirection = Quaternion.Euler(0, 45, 0) * moveDirection;
        moveDirection = moveDirection.normalized * speed;
        moveDirection.y = y;

        character.Move(moveDirection * Time.deltaTime);

        moveDirection.y += (Physics.gravity.y * gravityScale * Time.deltaTime);


    
    }

    private void Turning()
    {
        Vector2 input = lookPosition;
        Vector3 lookDirection = new Vector3(input.x, 0, input.y);
        Vector3 lookRotation = mainCamera.transform.TransformDirection(lookDirection);
        lookRotation = Vector3.ProjectOnPlane(lookRotation, Vector3.up);
        
        if (lookRotation != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(lookRotation);
            playerModel.transform.rotation = newRotation;
        }
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
