using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

using Items;
using Utils;

public class Hotbar : MonoBehaviour
{
    public Text selectedItemName;

    public delegate void ItemSelected(Equipment item);
    public event ItemSelected OnItemSelected;

    public GameObject leftBumper;
    public GameObject rightBumper;
    public Inventory inventory;

    private PlayerInputActions inputActions;
    private HotbarSlot[] slots;
    private Coroutine currentItemNameCoroutine;
    private int currentItemIndex = -1;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.HotbarOneForward.performed += SelectNextItem;
        inputActions.PlayerControls.HotbarOneBack.performed += SelectLastItem;
        inputActions.PlayerControls.HotbarDeleteItem.performed += DeleteItem;
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Start()
    {
        inventory.OnItemAdded += OnItemAdded;
        inventory.OnItemRemoved += OnItemRemoved;
       // inventory.OnItemUsed += OnItemUsed;

        slots = GetComponentsInChildren<HotbarSlot>();
    }

    public void SelectNextItem(CallbackContext ctx)
    {
        if (GameState.instance.IsInTargetAcquisition) return;
        SelectNextItem();
    }

    public void SelectLastItem(CallbackContext ctx)
    {
        if (GameState.instance.IsInTargetAcquisition) return;
        SelectLastItem();
    }

    public void DeleteItem(CallbackContext ctx)
    {
        if (!GameState.instance.IsInShop) return;

        Equipment item = slots[currentItemIndex].item as Equipment;
        if (item == null || (item != null && item.type == ItemType.Fist)) return;
        Player.instance.inventory.RemoveItem(item);
    }

    public void SelectNextItem()
    {
        SelectItem(Mathf.Clamp(currentItemIndex + 1, 0, slots.Length));
    }

    public void SelectLastItem()
    {
        SelectItem(Mathf.Clamp(currentItemIndex - 1, 0, slots.Length));
    }

    public void SelectItem(int nextIndex)
    {
        if (List.InBounds(nextIndex, slots.Length))
        {
            SelectItem(slots[nextIndex].item, nextIndex);
        }
    }

    private void SelectItem(Item item, int index)
    {
        if (item != null && item is Equipment)
        {
            StopAllCoroutines();

            if (!GameState.instance.IsInShop) StartCoroutine(ShowSelectedName(item.name));

            FindObjectOfType<AudioManager>().Play("SelectedSound");
            OnItemSelected?.Invoke(item as Equipment);

            currentItemIndex = index;
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].SetSelected(i == index);
            }
        }
    }

    private void OnItemAdded(object sender, InventoryEvent e)
    {
        HotbarSlot slot = FindHotbarSlot(e.item);
        if (slot == null) slot = FindEmptyHotbarSlot();

        if (slot != null && e.item is Equipment)
        {
            slot.Add(e.item as Equipment);
        }

        if (currentItemIndex == -1)
        {
            SelectItem(0);
        }
    }

    private void OnItemRemoved(object sender, InventoryEvent e)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == e.item.slot.Id)
            {
                int itemCount = e.item.slot.Count;
                slots[i].UpdateCount(itemCount);

                if (itemCount == 0)
                {
                    slots[i].Clear();
                    UpdateItems();
                    SelectLastItem();
                }

                if (itemCount > 0) SelectItem(currentItemIndex);
                break;
            }
        }
    }

    private void UpdateItems()
    {
        for (int i = 0; i < slots.Length; i++) slots[i].Clear();

        List<InventorySlot> inventorySlots = new List<InventorySlot>(inventory.slots);
        inventorySlots.RemoveAll(slot => slot.Count == 0);

        for (int i = 0; i < slots.Length; i++)
        {
            if (List.InBounds(i, inventorySlots.Count))
            {
                Item item = inventorySlots[i].FirstItem;
                if (item != null && item is Equipment)
                {
                    slots[i].Add(item as Equipment);
                }
            }
        }
    }

    private HotbarSlot FindHotbarSlot(Item item)
    {
        foreach (HotbarSlot slot in slots)
        {
            if (slot.item != null && slot.item.name == item.name) return slot;
        }
        return null;
    }

    private HotbarSlot FindEmptyHotbarSlot()
    {
        foreach (HotbarSlot slot in slots) if (slot.item == null) return slot;
        return null;
    }

    private IEnumerator ShowSelectedName(string name)
    {
        selectedItemName.text = name;
        yield return new WaitForSeconds(1f);
        selectedItemName.text = "";
    }

    public void SetLeftBumperActive(bool active) => leftBumper.SetActive(active);
    public void SetRightBumperActive(bool active) => rightBumper.SetActive(active);
}
