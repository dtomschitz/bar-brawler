using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControls : MonoBehaviour
{
    public float interactionRange;
    public LayerMask interactionLayer;

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

        //SelectItem(0);
    }

    void Update()
    {
        HandleInput();
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
            if (equipment.CurrentItem != null)
            {
                equipment.CurrentItem.OnInteract();
            }
        }

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRange, interactionLayer);
            foreach(Collider collider in colliders)
            {
                Interactable interactable = collider.GetComponent<Interactable>();
                if (interactable != null) interactable.Interact();
            }
        }*/
    }

    private void SelectItem(int i)
    {
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
