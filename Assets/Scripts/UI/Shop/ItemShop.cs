using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ItemShop : FadeCanvasGroup
    {
        public GameObject categoriesContainer;
        public CategoryButton categoryButtonPrefab;
        public ShopPage shopPagePrefab;

        public List<Category> categories;

        private List<ShopPage> pages;
        private ShopPage currentPage;

        private bool isOpen = false;

        void Start()
        {
            pages = new List<ShopPage>(categories.Count);

            InstantiateCategories();
            OnPageChange(0);
        }

        private void OnPageChange(int id)
        {
            if (currentPage != null)
            {
                ShopPage newPage = pages[id];
                currentPage.SetActive(false);
                newPage.SetActive(true);
                currentPage = newPage;
                return;
            }

            currentPage = pages[id];
            currentPage.SetActive(true);
        }

        private void InstantiateCategories()
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
        }

        public bool IsOpen
        {
            get { return isOpen; }

            set
            {
                if (isOpen == value) return;

                isOpen = value;
                if (isOpen)
                {
                    StopAllCoroutines();
                    gameObject.SetActive(true);
                    FadeIn(gameObject.GetComponent<CanvasGroup>(), .2f);
                }
                else
                {
                    StopAllCoroutines();
                    FadeOut(gameObject.GetComponent<CanvasGroup>(), .2f);
                    StartCoroutine(FadeOutShop(.2f, isOpen));
                }
            }
        }

        private IEnumerator FadeOutShop(float time, bool active)
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(active);
        }
    }
}