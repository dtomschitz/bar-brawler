namespace Shop
{
    public class ItemShop : FadeCanvasGroup
    {
        public CategoryButton[] categoryButtons;
        public ShopPage[] shopPages;

        public bool IsOpen { get; set; } = false;
        private ShopPage currentPage;

        void Start()
        {
            categoryButtons = GetComponents<CategoryButton>();
            OnPageSelected(0);
        }

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