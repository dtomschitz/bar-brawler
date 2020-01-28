using UnityEngine;
using UnityEngine.UI;
using Items;

public class HotbarSlot : MonoBehaviour
{
    [Header("Sprites")]
    public Image background;
    public Sprite selectedSprite;
    public Sprite defaultSprite;

    [Header("Item")]
    public Equipment item;
    public Image icon;
    public Sprite iconPlaceholder;
    public Text count;
    public GameObject durationPanel;
    public Image durationImage;

    public bool IsDragAndDropEnabled { get; set; } = true;

    public void Add(Equipment item)
    {
        this.item = item;

        icon.sprite = item.icon;
        icon.color = Color.white;
        icon.enabled = true;

        if (item.isStackable)
        {
            count.gameObject.SetActive(true);
            count.text = item.slot.Count.ToString();
        }

        if (item.hasDuration)
        {
            durationPanel.SetActive(true);
            durationImage.fillAmount = 1;
            item.OnDurationUpdate += UpdateDuration;
        }
    }

    public void Clear()
    {
        item = null;

        icon.color = Color.clear;
        icon.sprite = iconPlaceholder;
        
        count.gameObject.SetActive(true);
        count.text = "";

        durationPanel.SetActive(false);
    }

    public void UpdateCount(int currenCount)
    {
        count.text = currenCount.ToString();
    }

    public void UpdateDuration(float duration, float maxDuration)
    {
        durationImage.fillAmount = duration / maxDuration;
    }

    public void SetSelected(bool selected)
    {
        background.sprite = selected ? selectedSprite : defaultSprite;
    }
}
