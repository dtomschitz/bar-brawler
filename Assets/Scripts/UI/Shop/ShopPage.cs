﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class ShopPage : MonoBehaviour
    {
        public int id;
        public ItemSlot itemSlotPrefab;

        private List<ItemSlot> slots = new List<ItemSlot>();

        void LateUpdate()
        {
            ValidatePlayerCash();
        }

        private void ValidatePlayerCash()
        {
            int currentMoneyAmount = Player.instance.currentBalance;
            foreach (ItemSlot slot in slots)
            {
                slot.button.interactable = currentMoneyAmount >= slot.shopItem.price;
            }
        }

        public void AddItems(List<ShopItem> items)
        {
            if (items.Count == 0) return;

            foreach (ShopItem item in items)
            {
                ItemSlot slot = Instantiate(itemSlotPrefab, transform) as ItemSlot;
                slot.AddItem(item);
                slot.button.onClick.AddListener(delegate { OnItemBought(item); });

                slots.Add(slot);
            }
        }

        public void OnItemBought(ShopItem shopItem)
        {
            if (Player.instance.currentBalance >= shopItem.price)
            {
                shopItem.OnItemBought();
            }
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}