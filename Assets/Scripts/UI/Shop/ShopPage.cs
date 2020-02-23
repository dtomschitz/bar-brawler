using UnityEngine;

namespace Shop
{
    /// <summary>
    /// Class <c>ShopPage</c> is uses as a management class to handle a items
    /// page for an specific category. The class also contains an reference to
    /// the <see cref="ItemInfo"/> of this page.
    /// </summary>
    public class ShopPage : MonoBehaviour
    {
        public ItemInfo itemInfo;

        /// <summary>
        /// Updates the item informationen on the right side of the shop ui.
        /// </summary>
        /// <param name="item">The item which the user has selected.</param>
        public void OnItemSelected(ShopItem item)
        {
            itemInfo.SetItem(item);
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}