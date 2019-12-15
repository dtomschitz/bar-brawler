using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/Item")]
public class ShopItem : ScriptableObject
{
    public Item item;
    public int price;
}
