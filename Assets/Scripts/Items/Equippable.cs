using System;

namespace Items
{
    public class Equippable : Collectable
    {
        public bool isPrimaryEnabled = true;
        public bool isSecondaryEnabled = false;

        protected Entity owner;

        protected virtual void Start()
        {
            owner = GetComponentInParent<Entity>();
            if (owner == null) throw new ArgumentException("The item owner can't be null!");
        }

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
            if (!entity.combat.IsBlocking) entity.OnHit(owner);

            if (entity is Enemy && owner is Player && item.hasDuration)
            {
                item.UseItem();
                if (item.CurrentDuration <= 0)
                {
                    Player.instance.inventory.RemoveItem(item);
                    return;
                }
            }
        }

        public void OnEquip()
        {
            isCollected = true;
        }
    }
}