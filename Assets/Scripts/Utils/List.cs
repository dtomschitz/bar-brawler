using UnityEngine;

namespace Utils
{
    public class List : MonoBehaviour
    {
        public static bool InBounds(int index, int length)
        {
            return (index >= 0) && (index < length);
        }
    }
}
