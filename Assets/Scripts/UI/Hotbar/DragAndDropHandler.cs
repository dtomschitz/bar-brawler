using UnityEngine;
using UnityEngine.EventSystems;
using Items;

public class DragAndDropHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IDropHandler
{
    public Item item;
    public bool isEnabled = true;

    public void OnDrag(PointerEventData e)
    {
        if (isEnabled && !IsFistItem)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData e)
    {
        if (isEnabled && !IsFistItem) transform.localPosition = Vector3.zero;
    }


    public void OnDrop(PointerEventData e)
    {
        RectTransform panel = GetComponentInParent<Hotbar>().transform as RectTransform;
        if (!RectTransformUtility.RectangleContainsScreenPoint(panel, Input.mousePosition))
        {
            Debug.Log("Drop item: " + item.name + "(" + item.slot.Id + ")");
            Player.instance.inventory.RemoveItem(item);
        }
    }

    private bool IsFistItem
    {
       get {
            return item != null && item.type == ItemKind.Weapon && item is Equipment && (item as Equipment).itemType == ItemType.Fist;
        }
    }
}
