using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/Item")]
public class ShopItem : ScriptableObject
{
    new public string name;
    public Sprite icon;
    public Item item;
    public double price;
}
