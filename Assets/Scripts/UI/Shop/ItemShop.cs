using System.Collections.Generic;

namespace Shop
{
    public class ItemShop : FadeCanvasGroup
    {
        //public GameObject categoriesContainer;
        // public CategoryButton categoryButtonPrefab;
        // public ShopPage shopPagePrefab;
        //public List<Category> categories;

        public CategoryButton[] categoryButtons;
        public ShopPage[] shopPages;

        public bool IsOpen { get; set; } = false;

       // private List<ShopPage> pages;
        private ShopPage currentPage;

        void Start()
        {
            //pages = new List<ShopPage>(categories.Count);
            categoryButtons = GetComponents<CategoryButton>();

           // InstantiateCategories();
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



        /*private void InstantiateCategories()
        {
            for (int i = 0; i < categories.Count; i++)
            {
                Category category = categories[i];
                InstantiateCategoryButton(i, category);
                InstantiateShopPage(i, category);
            }
        }

        private void InstantiateCategoryButton(int id, Category category)
        {
            CategoryButton button = Instantiate(categoryButtonPrefab, categoriesContainer.transform) as CategoryButton;
            button.id = id;
            button.title.text = category.name;

            button.GetComponent<Button>().onClick.AddListener(delegate { OnPageChange(id); });
        }

        private void InstantiateShopPage(int id, Category category)
        {
            ShopPage page = Instantiate(shopPagePrefab, transform) as ShopPage;
            page.id = id;
            page.AddItems(category.items);
            page.SetActive(false);

            pages.Add(page);
        }*/
    }
}