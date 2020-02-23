using UnityEngine;
using Utils;

namespace Shop
{
    public class Shop : MonoBehaviour
    {
        public CategoryButton[] categoryButtons;
        public ShopPage[] shopPages;

        public bool IsOpen { get; set; } = false;
        private ShopPage currentPage;

        void Start()
        {
            OnPageSelected(0);
        }

        /// <summary>
        /// Opens the associated <see cref="ShopPage"/> trough the given id.
        /// </summary>
        /// <param name="id">The index of the shop page in the set <see cref="shopPages"/> array.</param>
        public void OnPageSelected(int id)
        {
            UpdateCategoryHighlight(id);

            if (currentPage != null)
            {
                ShopPage newPage = shopPages[id];
                currentPage.SetActive(false);
                newPage.SetActive(true);
                currentPage = newPage;
                return;
            }

            currentPage = shopPages[id];
            currentPage.SetActive(true);
        }

        private void UpdateCategoryHighlight(int id)
        {
            for (int i = 0; i < categoryButtons.Length; i++)
            {
                categoryButtons[i].SetSelected(i == id);
            }
        }
    }
}