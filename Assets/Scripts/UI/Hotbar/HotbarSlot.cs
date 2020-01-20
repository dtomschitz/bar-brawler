using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Items;

public class HotbarSlot : MonoBehaviour, IDragHandler, IEndDragHandler, IDropHandler
{
    public int id;
    public Item item;
    public Image icon;
    public Sprite iconPlaceholder;
    public Text count;

    public bool IsDragAndDropEnabled { get; set; } = true;

    private Transform canvas;
    private Transform startParent;
    private Vector3 startPosition;


    public void Add(int id, Item item)
    {
        this.id = id;
        this.item = item;

        icon.sprite = item.icon;
        icon.color = Color.white;
        icon.enabled = true;

        if (item.isStackable)
        {
            count.gameObject.SetActive(true);
            count.text = item.slot.Count.ToString();
        }
    }

    public void Clear()
    {
        id = -1;
        item = null;

        icon.sprite = iconPlaceholder;
        
        count.gameObject.SetActive(true);
        count.text = "";
    }

    public void OnBeginDrag(PointerEventData e)
    {
    }

    public void OnDrag(PointerEventData e)
    {
        if (IsDragAndDropEnabled && !IsFistItem)
        {
            icon.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData e)
    {
        if (IsDragAndDropEnabled && !IsFistItem)
        {
            icon.transform.localPosition = Vector3.zero;
        }
    }


    public void OnDrop(PointerEventData e)
    {
        if (e.pointerDrag != null)
        {
            HotbarSlot hotbarSlot = e.pointerDrag.GetComponent<HotbarSlot>();
            Debug.Log(hotbarSlot.id);
        }
    }

    private bool IsFistItem
    {
        get
        {
            return item != null && item.type == ItemKind.Weapon && item is Equipment && (item as Equipment).itemType == ItemType.Fist;
        }
    }
}
