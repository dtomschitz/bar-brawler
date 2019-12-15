using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControls : MonoBehaviour
{

    //public float moveSpeed;
    //public float jumpForce;
    //public CharacterController character;

   // public GameObject playerModel;
    //public Transform pivot;
    //public float rotateSpeed;
    //public float gravityScale;

    //private Vector3 moveDirection;

    public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged onFocusChanged;
    EntityInteraction focus;

    private Inventory inventory;
    private EquipmentManager equipment;

    private int selectedHotbarIndex = 0;
    private KeyCode[] hotbarControls = new KeyCode[]
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
    };

    void Start()
    {
        inventory = GetComponent<Inventory>();
        equipment = GetComponent<EquipmentManager>();
        //character = GetComponent<CharacterController>();

        //SelectItem(0);
    }

    void Update()
    {
        HandleInput();
        //Movement();
    }

   /*private void Movement()
    {
        float yStore = moveDirection.y;

        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (character.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }


        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        character.Move(moveDirection * Time.deltaTime);

        /*if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
           // transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
           // Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            //playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

    }*/

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (equipment.CurrentItem != null)
            {
                equipment.CurrentItem.OnInteract();
            }
        }

        for (int i = 0; i < hotbarControls.Length; i++)
        {
            if (Input.GetKeyDown(hotbarControls[i]))
            {
                selectedHotbarIndex = i;
                if (selectedHotbarIndex < inventory.slots.Count)
                {
                    SelectItem(selectedHotbarIndex);
                }
            }
        }
    }

    private void SelectItem(int i)
    {
        Item item = inventory.slots[i].FirstItem;
        //if (item != null) inventory.UseItem(item as Equippable);
        if (item != null && item is Equipment) equipment.EquipItem(item as Equipment);
    }

    private void SetFocus(EntityInteraction newFocus)
    {
        if (onFocusChanged != null)
        {
            onFocusChanged.Invoke(newFocus);
        }

        if (focus != newFocus && focus != null)
        {
            focus.OnUnfocused();
        }

        focus = newFocus;
        if (focus != null)
        {
            focus.OnFocused(transform);
        }
    }
}
