﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControls : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float jumpForce;
    public float gravityScale;
    public float rotateSpeed;
    private Vector3 moveDirection;

    [Header("Interaction")]
    public float interactionRange;
    public LayerMask enemyLayer;
    public LayerMask barkeeperLayer;

    [Header("Model")]
    public GameObject playerModel;
    public Transform pivot;

    private Rigidbody playerRigidbody;
    private CharacterController character;
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
        playerRigidbody = GetComponent<Rigidbody>();
        character = GetComponent<CharacterController>();
        inventory = GetComponent<Inventory>();
        equipment = GetComponent<EquipmentManager>();
        
        SelectItem(0);
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, v);
        HandleInput();
    }

    private void Move(float h, float v)
    {
        float yStore = moveDirection.y;

        // moveDirection.Set(h, 0f, v);
        moveDirection = (transform.forward * v) + (transform.right * h);
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


        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        character.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
    }

    private void HandleInput()
    {
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

        if (Input.GetMouseButtonDown(0))
        {
            //TODO: Update item system and remove double implementation
            if (equipment.CurrentItem != null && equipment.CurrentItem is Revolver)
            {
                Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit floorHit;

                if (Physics.Raycast(camRay, out floorHit, enemyLayer))
                {
                    Vector3 playerToMouse = floorHit.point - transform.position;
                    playerToMouse.y = 0f;

                    Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
                    playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, 1000f * Time.deltaTime);
                }
                equipment.CurrentItem.OnInteract();
            } else
            {
                equipment.CurrentItem.OnInteract();
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (equipment.CurrentEquipment != null && equipment.CurrentEquipment.type == ItemType.Consumable)
            {
                Debug.Log("Use Drink");
                inventory.UseItem(equipment.CurrentEquipment);
            }

            /*Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRange, barkeeperLayer);
            foreach(Collider collider in colliders)
            {
                Debug.Log(collider);
                Interactable interactable = collider.GetComponent<Interactable>();
                if (interactable != null) interactable.Interact();
            }*/
        }
    }

    private void SelectItem(int i)
    {
        Debug.Log(inventory.slots.Count);
        Item item = inventory.slots[i].FirstItem;
        //if (item != null) inventory.UseItem(item as Equippable);
        if (item != null && item is Equipment) equipment.EquipItem(item as Equipment);
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionRange == 0f) return;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
