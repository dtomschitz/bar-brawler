using UnityEngine;

namespace Items {

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
