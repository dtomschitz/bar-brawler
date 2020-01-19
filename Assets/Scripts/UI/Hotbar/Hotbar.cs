using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Items;

public class Hotbar : MonoBehaviour
{
    public Text selectedItemName;

    public delegate void ItemSelected(Equipment item);
    public event ItemSelected OnItemSelected;

    private Inventory inventory;
    private HotbarSlot[] slots;

    private Coroutine currentItemNameCoroutine;

    private int selectedHotbarIndex = 0;
    private readonly KeyCode[] hotbarControls = new KeyCode[]
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
    };

    void Start()
    {
        inventory = Player.instance.inventory;
        inventory.ItemAdded += OnItemAdded;
        inventory.ItemRemoved += OnItemRemoved;

        WaveSpawner.instance.OnWaveStateUpdate += OnWaveStateUpdate;

        slots = GetComponentsInChildren<HotbarSlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            HotbarSlot slot = slots[i];
            slot.Clear();
        }

        SelectItem(0);
    }

    void Update()
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
    }

    private void OnItemAdded(object sender, InventoryEvent e) 
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == e.item.slot.Id)
            {
                slots[i].Add(e.item);
                break;
            }
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

    private void OnWaveStateUpdate(WaveState state)
    {
        bool isEnabled = !WaveSpawner.instance.IsWaveRunning;

        for (int i = 0; i < slots.Length; i++)
        {
            EnableDragHandler(slots[i], isEnabled);
        }
    }

    private void SelectItem(int hotbarIndex)
    {
        Item item = inventory.slots[hotbarIndex].FirstItem;
        if (item != null && item is Equipment)
        {
            if (currentItemNameCoroutine != null)
            {
                StopCoroutine(currentItemNameCoroutine);
                currentItemNameCoroutine = null;
            }

            currentItemNameCoroutine = StartCoroutine(ShowSelectedName(item.name));
            OnItemSelected?.Invoke(item as Equipment);
        }
    }

    private void EnableDragHandler(HotbarSlot hotbarSlot, bool isEnabled)
    {
        hotbarSlot.GetComponentInChildren<DragAndDropHandler>().isEnabled = isEnabled;
    }

    private IEnumerator ShowSelectedName(string name)
    {
        selectedItemName.text = name;
        yield return new WaitForSeconds(1f);
        selectedItemName.text = "";
    }
}
