using UnityEngine;
using UnityEngine.UI;


public class HotbarSlot : MonoBehaviour
{
    public Image icon;
    public Text count;
    public DragAndDropHandler dragAndDropHandler;

    public void Add(Item item)
    {
        icon.sprite = item.icon;
        icon.color = Color.white;
        icon.enabled = true;

        dragAndDropHandler.item = item;

        if (item.isStackable)
        {
            count.gameObject.SetActive(true);
            count.text = item.slot.Count.ToString();
        }
    }

    public void Clear()
    {
        icon.sprite = null;
        icon.enabled = false;

        dragAndDropHandler.item = null;

        count.gameObject.SetActive(true);
        count.text = "";
    }
}
