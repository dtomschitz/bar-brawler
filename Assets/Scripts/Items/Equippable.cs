using System;

namespace Items
{
    /// <summary>
    /// Class <c>Equippable</c> is used as an base class for all game objects which
    /// gould get equipped by the <see cref="EntityEquipment"/> class. This class
    /// implements also the methods for triggering the primary and secondary
    /// actions from the respective item.
    /// </summary>
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

        public void OnEquip()
        {
            isCollected = true;
        }
    }
}