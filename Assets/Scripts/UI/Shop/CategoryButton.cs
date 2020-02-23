using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class CategoryButton : MonoBehaviour
    {
        public Color defaultColor;
        public Color selectedColor;

        public void SetSelected(bool selected)
        {
            GetComponent<Text>().color = selected ? selectedColor : defaultColor;
        }
    }
}
