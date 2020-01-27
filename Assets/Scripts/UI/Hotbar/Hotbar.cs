using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Items;
using static UnityEngine.InputSystem.InputAction;

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

    public void UpdateItems(Item _)
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            slots[i].Clear();
        }

        for (int i = 0; i < inventory.slots.Count; i++)
        {
            Item item = inventory.slots[i].FirstItem;
            if (item != null)
            {
                slots[i].Add(item);
            }
        }
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
        SelectItem(currentItemIndex + 1);
    }

    public void SelectLastItem()
    {
        SelectItem(currentItemIndex - 1);
    }

    public void SelectItem(int nextIndex)
    {
        if (InBounds(nextIndex, slots))
        {
            SelectItem(slots[nextIndex].item, nextIndex);
        }
    }

    private void SelectItem(Item item, int index)
    {
        if (item != null && item is Equipment)
        {
            if (currentItemNameCoroutine != null)
            {
                StopCoroutine(currentItemNameCoroutine);
                currentItemNameCoroutine = null;
            }

            currentItemNameCoroutine = StartCoroutine(ShowSelectedName(item.name));
            OnItemSelected?.Invoke(item as Equipment);

            currentItemIndex = index;
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].SetSelected(i == index);
            }
        }
    }

    private void OnItemAdded(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == item.slot.Id)
            {
                slots[i].Add(item);
                break;
            }
        }

        if (currentItemIndex == -1)
        {
            SelectItem(0);
        }
    }

    private void OnItemRemoved(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == item.slot.Id)
            {
                int itemCount = item.slot.Count;
                slots[i].UpdateCount(itemCount);

                if (itemCount == 0)
                {
                    slots[i].Clear();    
                    SelectItem(Mathf.Clamp(currentItemIndex - 1, 0, int.MaxValue));
                }

                if (itemCount > 0)
                {
                    SelectItem(currentItemIndex);
                }
                break;
            }
        }
    }

    private void OnItemUsed(Item item)
    {
        Debug.Log(item.slot.Count);

        if (item.slot.Count > 0)
        {
            SelectItem(currentItemIndex);
        }
    }
  
    private IEnumerator ShowSelectedName(string name)
    {
        selectedItemName.text = name;
        yield return new WaitForSeconds(1f);
        selectedItemName.text = "";
    }

    public void SetLeftBumperActive(bool active) => leftBumper.SetActive(active);
    public void SetRightBumperActive(bool active) => rightBumper.SetActive(active);

    private bool InBounds(int index, HotbarSlot[] slots)
    {
        return (index >= 0) && (index < slots.Length);
    }
}
