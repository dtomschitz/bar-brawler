using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Utils;

namespace Shop
{
    /// <summary>
    /// Class <c>ShopButton</c> is used as an management script to detect wether
    /// the user wants to buy an item or not. 
    /// </summary>
    public class ShopButton : FadeGraphic, ISelectHandler
    {
        public Text title;
        public Button button;

        public ShopItem shopItem;

        void Start()
        {
            title.text = shopItem.item.name.ToUpper();
        }

        /// <summary>
        /// Gets triggerd if the user has selected an shop button.
        /// </summary>
        /// <param name="eventData"></param>
        public void OnSelect(BaseEventData eventData)
        {
            GetComponentInParent<ShopPage>().OnItemSelected(shopItem);
        }

        public Text eventText;


        /// <summary>
        /// Gets triggered if the user pressed the current selected button. This
        /// method will then start validating whether the user can buy the
        /// associated item or not.
        /// </summary>
        public void OnClick()
        {
            StopAllCoroutines();
            eventText.text = "";
            eventText.color = Color.white;

            FadeIn(eventText, .5f);

            PlayerInventory inventory = Player.instance.inventory;
            if (inventory != null)
            {
                if (Player.instance.CurrentBalance < shopItem.price)
                {
                    eventText.text = "Du hast nicht genug Geld!".ToUpper();
                    StartCoroutine(HideEventText());
                    return;
                }

                if (!(shopItem is Munition))
                {
                    if (!inventory.HasItem(shopItem.item) && inventory.FindStackableSlot(shopItem.item) == null && inventory.FindNextEmptySlot() == null)
                    {
                        eventText.text = "Dein Inventar ist voll!".ToUpper();
                        StartCoroutine(HideEventText());
                        return;
                    }

                    if (inventory.HasItem(shopItem.item) && inventory.FindStackableSlot(shopItem.item) == null)
                    {
                        eventText.text = "Du hast schon zu viele Items dieser Art".ToUpper();
                        StartCoroutine(HideEventText());
                        return;
                    }
                }

                shopItem.OnItemBought();
            }
        }

        private IEnumerator HideEventText()
        {
            yield return new WaitForSeconds(2f);
            FadeOut(eventText, .5f);
            yield return new WaitForSeconds(.5f);

            eventText.text = "";
        }
    }
}
