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
    private int selectedItemIndex = -1;

    void Awake()
    {
        inputActions = new PlayerInputActions();

        inputActions.PlayerControls.HotbarOneForward.performed += SelectNextItem;
        inputActions.PlayerControls.HotbarOneBack.performed += SelectLastItem;
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

        WaveSpawner.instance.OnWaveStateUpdate += OnWaveStateUpdate;

        slots = GetComponentsInChildren<HotbarSlot>();
    }

    public void SetLeftBumperActive(bool active) => leftBumper.SetActive(active);
    public void SetRightBumperActive(bool active) => rightBumper.SetActive(active);
  

    private void OnItemAdded(object sender, InventoryEvent e) 
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == e.item.slot.Id)
            {
                slots[i].Add(i, e.item);
                break;
            }
        }

        if (selectedItemIndex == -1)
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
                if (itemCount == 0)
                {
                    slots[i].Clear();
                }
                break;
            }
        }
    }

    private void OnWaveStateUpdate(WaveState state, int rounds)
    {
        bool isEnabled = !WaveSpawner.instance.IsWaveRunning;

        for (int i = 0; i < slots.Length; i++)
        {
            EnableDragHandler(slots[i], isEnabled);
        }
    }

    public void SelectNextItem(CallbackContext ctx)
    {
        SelectItem(selectedItemIndex + 1);
    }

    public void SelectLastItem(CallbackContext ctx)
    {
        SelectItem(selectedItemIndex - 1);
    }

    public void SelectItem(int index)
    {
        if (InBounds(index, slots))
        {
            SelectItem(slots[index].item, index);
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

            selectedItemIndex = index;
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].SetSelected(i == index);
            }
        }
    }

    private void EnableDragHandler(HotbarSlot hotbarSlot, bool isEnabled)
    {
        hotbarSlot.IsDragAndDropEnabled = isEnabled;
    }

    private IEnumerator ShowSelectedName(string name)
    {
        selectedItemName.text = name;
        yield return new WaitForSeconds(1f);
        selectedItemName.text = "";
    }

    private bool InBounds(int index, HotbarSlot[] slots)
    {
        return (index >= 0) && (index < slots.Length);
    }

}
