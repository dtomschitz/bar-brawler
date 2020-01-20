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
    private Vector3 moveDirection;
    private Vector3 moveVelocity;


    [Header("Interaction")]
    public float interactionRange;
    public LayerMask enemyMask;
    public LayerMask barkeeperMask;
    public LayerMask groundMask;

    [Header("Model")]
    public GameObject playerModel;
    public Transform pivot;


    private CharacterController character;
    private Rigidbody playerRigidbody;
    private Inventory inventory;
    private EquipmentManager equipment;

    void Start()
    {
        character = GetComponent<CharacterController>();
        playerRigidbody = GetComponent<Rigidbody>();
        inventory = GetComponent<Inventory>();
        equipment = GetComponent<EquipmentManager>();
    }

    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        if (IsMovementEnabled)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Move(h, v);
        }
        Turning();
    }

    private void Move(float horizontal, float vertical)
    {
        float y = moveDirection.y;

        moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection = Quaternion.Euler(0, 45, 0) * moveDirection;
        moveDirection.y = y;

        moveDirection = moveDirection.normalized * speed * Time.deltaTime;
        character.Move(moveDirection);

        moveDirection.y += (Physics.gravity.y * gravityScale * Time.deltaTime);


        /*float yStore = moveDirection.y;

        moveDirection = (transform.forward * v);
        moveDirection = moveDirection.normalized * speed;
        moveDirection.y = yStore;

        if (character.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }


        character.Move(moveDirection * Time.deltaTime);
        moveDirection.y += (Physics.gravity.y * gravityScale * Time.deltaTime);


        //moveDirection = new Vector3(h, 0f, v);
        //moveVelocity = moveDirection * speed;

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(camRay, out RaycastHit floorHit))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            rigidbody.MoveRotation(newRotation);
            //rigidbody.MoveRotation(Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime));
            //rigidbody.MovePosition(floorHit.point);
        }

        /*if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }*/
    }

    private void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, cameraRayLength))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
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
