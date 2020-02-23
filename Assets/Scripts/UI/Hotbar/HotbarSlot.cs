using UnityEngine;
using UnityEngine.UI;
using Items;

/// <summary>
/// Class <c>HotbarSlot</c> is used in the hotbar ui element as an single element
/// where the set item can be representet. The class handles the adding and clearing
/// as well as the updating of the stack count and the duration.
/// </summary>
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

    /// <summary>
    /// Adds an new item into this hotbar slot, updates the icon, the stack
    /// count and the duration if the item has one. If the item has a duration
    /// the method wil subsribe to the <see cref="Equipment.OnDurationUpdate"/>
    /// event.
    /// </summary>
    /// <param name="item">The item taht was added to the slot.</param>
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
            item.OnDurationUpdate += OnDurationUpdate;
        }
    }

    /// <summary>
    /// Clears the current item from this slot, resets the icon to the default
    /// placeholder, disabled the stack count and the duration bar.
    /// </summary>
    public void Clear()
    {
        item = null;

        icon.color = Color.clear;
        icon.sprite = iconPlaceholder;
        
        count.gameObject.SetActive(true);
        count.text = "";

        durationPanel.SetActive(false);
    }

    /// <summary>
    /// Updates the visual stack count of the item.
    /// </summary>
    /// <param name="currenCount">The current count of this specific item.</param>
    public void UpdateCount(int currenCount) => count.text = currenCount.ToString();

    /// <summary>
    /// Updates the duration bar fill amount with the given normalized duration
    /// of the item.
    /// </summary>
    /// <param name="normalizedDuration">The normalized duration of the current set item.</param>
    public void OnDurationUpdate(float normalizedDuration) => durationImage.fillAmount = normalizedDuration;

    /// <summary>
    /// This method can be used to mark this specific <see cref="HotbarSlot"/>
    /// as selected.
    /// </summary>
    public void SetSelected(bool selected) => background.sprite = selected ? selectedSprite : defaultSprite;
}
