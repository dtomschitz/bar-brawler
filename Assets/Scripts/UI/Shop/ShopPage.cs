using UnityEngine;

namespace Shop
{
    public class ShopPage : MonoBehaviour
    {
        public ItemInfo itemInfo;

        public void OnItemSelected(ShopItem item)
        {
            itemInfo.SetItem(item);
            //FindObjectOfType<AudioManager>().Play("SelectedSound");
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}