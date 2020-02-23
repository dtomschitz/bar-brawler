using UnityEngine;

namespace Wave
{
    public class SpawnPoint : MonoBehaviour
    {
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