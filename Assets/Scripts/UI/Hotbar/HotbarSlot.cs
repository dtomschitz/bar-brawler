using UnityEngine;
using UnityEngine.UI;


public class HotbarSlot : MonoBehaviour
{
    public Image icon;
    public Text slotNumber;

    private Color color = Color.white;

    public int SlotNumber
    {
        set { slotNumber.text = value.ToString(); }
    }

    public bool Selected
    {
        set {
            if (value)
            {
                //icon.color = Color.white.a;
                color.a = 1.0f;
            } else
            {
                color.a = .6f;

            }
        }
    }


    public void Add(Item item)
    {
        icon.sprite = item.icon;
        icon.color = color;
        icon.enabled = true;
    }

    public void Clear()
    {
        icon.sprite = null;
        icon.enabled = false;
    }
}
