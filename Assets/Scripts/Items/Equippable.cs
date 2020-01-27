using UnityEngine;

namespace Items
{
    public class Equippable : Collectable
    {
        public bool isPrimaryEnabled = true;
        public bool isSecondaryEnabled = false;

        void Start()
        {
            if (!(item is Equipment))
            {
                throw new UnityException("Item is not of the type Equipment");
            }
        }

        public virtual void OnPrimary()
        {
            if (!isPrimaryEnabled) return;

            Equipment equipment = item as Equipment;
            if (equipment.duration - 1 <= 0) return;
        }

        public virtual void OnSecondary()
        {
            if (!isSecondaryEnabled) return;
        }

        public void OnEquip()
        {
            isCollected = true;
        }

        public virtual void OnDrop()
        {
            isCollected = false;
            /*RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000))
            {
                equipmentObject.SetActive(true);
                equipmentObject.transform.position = hit.point;
                equipmentObject.transform.eulerAngles = item.dropRotation;
            }*/
        }
    }
}