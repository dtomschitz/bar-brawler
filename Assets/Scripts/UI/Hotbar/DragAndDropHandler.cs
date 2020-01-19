using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IDropHandler
{
    public Item item;
    public bool isEnabled = true;

    public void OnDrag(PointerEventData e)
    {
        if (isEnabled)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData e)
    {
        if (isEnabled) transform.localPosition = Vector3.zero;
    }


    public void OnDrop(PointerEventData e)
    {
        RectTransform panel = GetComponentInParent<Hotbar>().transform as RectTransform;
        if (!RectTransformUtility.RectangleContainsScreenPoint(panel, Input.mousePosition))
        {
            Debug.Log("Drop item: " + item.name);
            Player.instance.inventory.RemoveItem(item);
        }
    }
}
