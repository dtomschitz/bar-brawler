namespace Items
{
    public class Equippable : Collectable
    {
        public bool isPrimaryEnabled = true;
        public bool isSecondaryEnabled = false;

        public virtual void OnPrimary()
        {
            if (!isPrimaryEnabled) return;
        }

        public virtual void OnSecondary()
        {
            if (!isSecondaryEnabled) return;
        }

        public virtual void OnHit(Entity entity)
        {
            //enemy.Interact();
            //entity.

            if (entity is Enemy)
            {
                if (item.hasDuration)
                {
                    item.UseItem();
                    if (item.CurrentDuration <= 0)
                    {
                        Player.instance.inventory.RemoveItem(item);
                        return;
                    }
                }
            }
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