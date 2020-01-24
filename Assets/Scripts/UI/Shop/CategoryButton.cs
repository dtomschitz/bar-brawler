using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Shop
{
    public class CategoryButton : MonoBehaviour, ISelectHandler
    {
        public int id;
        public Text title;

        public Color defaultColor;
        public Color selectedColor;

        public void OnSelect(BaseEventData eventData)
        {
            GetComponentInParent<ItemShop>().OnPageSelected(id);
        }

        public void SetSelected(bool selected)
        {
            title.color = selected ? selectedColor : defaultColor;
        }
    }
}
