using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

using Items;
using Utils;

/// <summary>
/// Class <c>Hotbar</c> is used to visualize the items the player has in his
/// inventory. Through this class the user can select on of the items in the
/// hotbar in order to equipp it to the player. The class also handles the
/// updating process if the player received an item, lost one or used one.
/// In the beginning this class also adds the default items to the inventory of
/// the player and selects the first item of it.
/// </summary>
public class Hotbar : MonoBehaviour
{
    public Text selectedItemName;

    public delegate void ItemSelected(Equipment item);
    public event ItemSelected OnItemSelected;

    public GameObject leftBumper;
    public GameObject rightBumper;

    private Inventory inventory;
    private PlayerEquipment equipment;
    private PlayerInputActions inputActions;
    private HotbarSlot[] slots;
    private int currentItemIndex = -1;

    /// <summary>
    /// Subscribes to the set <see cref="PlayerInputActions"/> controlls. 
    /// </summary>
    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.HotbarOneForward.performed += SelectNextItem;
        inputActions.PlayerControls.HotbarOneBack.performed += SelectLastItem;
        inputActions.PlayerControls.HotbarDeleteItem.performed += DeleteItem;

        slots = GetComponentsInChildren<HotbarSlot>();
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
        inventory = Player.instance.inventory;
        equipment = Player.instance.equipment as PlayerEquipment;
        if (inventory == null) throw new ArgumentException("Player inventory cannot be null");
        if (equipment == null) throw new ArgumentException("Player equipment cannot be null");

        inventory.OnItemAdded += OnItemAdded;
        inventory.OnItemRemoved += OnItemRemoved;

        AddDefaultItems();
    }

    /// <summary>
    /// This method is used to subscribe to the specific <see cref="PlayerInputActions"/>
    /// method and gets called if the user pressed the button which should trigger
    /// the selecting of the next item in the hotbar. If the game state is currently set to
    /// <see cref="GameStateType.TargetAcquisition"/> the request will get rejected.
    /// </summary>
    /// <param name="ctx"></param>
    public void SelectNextItem(CallbackContext ctx)
    {
        if (GameState.instance.IsInTargetAcquisition/* || Player.instance.combat.IsInAction*/) return;
        SelectNextItem();
    }

    /// <summary>
    /// This method is used to subscribe to the specific <see cref="PlayerInputActions"/>
    /// method and gets called if the user pressed the button which should trigger
    /// the selecting of the last item in the hotbar. If the game state is currently set to
    /// <see cref="GameStateType.TargetAcquisition"/> the request will get rejected.
    /// </summary>
    /// <param name="ctx"></param>
    public void SelectLastItem(CallbackContext ctx)
    {
        if (GameState.instance.IsInTargetAcquisition/* || Player.instance.combat.IsInAction*/) return;
        SelectLastItem();
    }

    /// <summary>
    /// This method is used to subscribe to the specific <see cref="PlayerInputActions"/>
    /// method and gets called if the user pressed the button which should trigger
    /// the deleting of the current selected item. This method can only be used
    /// while the user has opened the shop. It should enable the player to delete
    /// unwanted items and free some space in the inventory in order to buy new
    /// items.
    /// </summary>
    /// <param name="ctx"></param>
    public void DeleteItem(CallbackContext ctx)
    {
        if (!GameState.instance.IsInShop) return;

        Equipment item = slots[currentItemIndex].item as Equipment;
        if (item == null || (item != null && item.type == ItemType.Fist)) return;

        Player.instance.inventory.RemoveItem(item);
    }

    /// <summary>
    /// Selects the next item in the hotbar.
    /// </summary>
    public void SelectNextItem()
    {
        SelectItem(Mathf.Clamp(currentItemIndex + 1, 0, slots.Length));
    }

    /// <summary>
    /// Selects the last item in the hotbar.
    /// </summary>
    public void SelectLastItem()
    {
        SelectItem(Mathf.Clamp(currentItemIndex - 1, 0, slots.Length));
    }

    /// <summary>
    /// Tries to select an item from the <see cref="Hotbar"/> with the given index.
    /// </summary>
    /// <param name="index">The position of the item in the hotbar</param>
    public void SelectItem(int index)
    {
        if (List.InBounds(index, slots.Length))
        {
            SelectItem(slots[index].item, index);
        }
    }

    /// <summary>
    /// This method selects an given item from the <see cref="Hotbar"/>, dislays
    /// the name of the selected item in the hud and fires the <see cref="OnItemSelected"/>
    /// event. It also updates the <see cref="HotbarSlot"/> and calls the
    /// <see cref="HotbarSlot.SetSelected(bool)"/> in order to visualize it.
    /// </summary>
    /// <param name="item">The item which should get selected.</param>
    /// <param name="index">The position of the item in the hotbar.</param>
    private void SelectItem(Item item, int index)
    {
        if (item != null && item is Equipment && index != currentItemIndex)
        {
            StopAllCoroutines();

            if (!GameState.instance.IsInShop) StartCoroutine(ShowSelectedName(item.name));

            OnItemSelected?.Invoke(item as Equipment);

            currentItemIndex = index;
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].SetSelected(i == index);
            }
        }
    }

    /// <summary>
    /// Gets called if an new item got added to the player inventory. The method
    /// will then find and and hotbar slot which is empty or contains the same
    /// type of item and has still enough space. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

    /// <summary>
    /// Gets called if an item got removed from the player inventory. The method
    /// will then determinate wether the given item is in general in the hotbar.
    /// Is this the case the item will get removed from the hotbar so the player
    /// can not use it anymore. But if the item stack count is not equals to zero
    /// the item will not get fully removed from the <see cref="Hotbar"/> nut
    /// rather the item count will get updated.
    /// </summary>in 
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

    /// <summary>
    /// This method will update the complete <see cref="Hotbar"/>. This happens
    /// by clearing all hotbarslots first and adding all the items from the
    /// inventory back into the <see cref="HotbarSlot"/>.
    /// </summary>
    private void UpdateItems()
    {
        for (int i = 0; i < slots.Length; i++) slots[i].Clear();

        List<InventorySlot> inventorySlots = new List<InventorySlot>(inventory.Slots);
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


    /// <summary>
    /// Adds all default items to the inventory and the hotbar itself. 
    /// </summary>
    private void AddDefaultItems()
    {
        foreach (Item item in equipment.defaultItems)
        {
            inventory.AddItem(item);
        }
        equipment.EquipFirstItem();
    }

    /// <summary>
    /// Tries to find a slot in the hotbar where the items got the same type.
    /// </summary>
    /// <param name="item">The item which should get added into a <see cref="HotbarSlot"/></param>
    /// <returns>The found hotbar slot if there is one; otherwise null.</returns>
    private HotbarSlot FindHotbarSlot(Item item)
    {
        foreach (HotbarSlot slot in slots)
        {
            if (slot.item != null && slot.item.name == item.name) return slot;
        }
        return null;
    }

    /// <summary>
    /// Tries to find an empty slot in the hotbar and returns it.
    /// </summary>
    /// <returns>The found hotbar slot if there is one; otherwise null.</returns>
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
