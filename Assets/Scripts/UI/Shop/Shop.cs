using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject categoriesContainer;
    public CategoryButton categoryButtonPrefab;
    public ShopPage shopPagePrefab;

    public List<Category> categories;

    private List<ShopPage> pages;
    private ShopPage currentPage;

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
        }

        currentPage = pages[id];
        currentPage.SetActive(true);
        return;
    }

    private void InstantiateCategories()
    {
        for (int i = 0; i < categories.Count; i++)
        {
            Category category = categories[i];
            InstantiateCategoryButton(i, category);
            InstantiateShopPage(i, category);
        }

        foreach (ShopPage page in pages) page.SetActive(false);
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

        pages.Add(page);
    }
}
