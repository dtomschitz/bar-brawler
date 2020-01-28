using UnityEngine;

namespace Wave
{
    public class SpawnPoint : MonoBehaviour
    {
        public Door door;

        public void OpenDoor()
        {
            if (door) door.OpenDoor();
        }

        public void CloseDoor()
        {
            if (door) door.CloseDoor();
        }
    }
}