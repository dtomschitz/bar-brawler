using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public Equipment item;

    void Start()
    {
        GetComponent<Hotbar>().OnItemSelected += OnItemSeleced;
    }
    
    public void OnItemSeleced(Equipment item)
    {
        this.item = item;
    }

    public void OnDrop(PointerEventData e) 
    {
        RectTransform panel = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(panel, Input.mousePosition))
        {
            Player.instance.inventory.RemoveItem(item);
        }
    }
}
