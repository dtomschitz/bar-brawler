using UnityEngine;

namespace Items {

    /// <summary> 
    /// Class <c>Collectable</c> is used to attach the functionality of picking
    /// up items to any game object in the level. The class also stores an
    /// reference to the actual item.
    /// </summary>
    public class Collectable : MonoBehaviour
    {
        public Equipment item;
        public bool isCollected = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !isCollected)
            {
                isCollected = true;
                item.OnCollection();
                OnCollection();
            }
        }

        public virtual void OnCollection()
        {
            Destroy(gameObject);
        }
    }
}
