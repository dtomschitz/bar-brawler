using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public bool isEnabled = true;

    public void OnDrag(PointerEventData e)
    {
        if (isEnabled) transform.position = Input.mousePosition; 
    }

    public void OnEndDrag(PointerEventData e)
    {
        if (isEnabled) transform.localPosition = Vector3.zero;
    }
}
