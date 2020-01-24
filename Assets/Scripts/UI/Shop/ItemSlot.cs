using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Shop
{
    public class ItemSlot : MonoBehaviour, ISelectHandler
    {
        public Text title;
        public Button button;

        public ShopItem shopItem;

        void Start()
        {
            title.text = shopItem.item.name.ToUpper();
        }

        public void OnSelect(BaseEventData eventData)
        {
            GetComponentInParent<ShopPage>().OnItemSelected(shopItem);
        }
    }
}