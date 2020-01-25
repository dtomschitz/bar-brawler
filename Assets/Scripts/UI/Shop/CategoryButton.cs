using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class CategoryButton : MonoBehaviour
    {
        public int id;
        public Text title;

        public Color defaultColor;
        public Color selectedColor;

        public void SetSelected(bool selected)
        {
            Debug.Log(id + " selected: " + selected);

            title.color = selected ? selectedColor : defaultColor;
        }
    }
}
