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

        public Vector3 Position
        {
            get { return transform.position; }
        }

        public Quaternion Rotation
        {
            get { return transform.rotation; }
        }
    }
}