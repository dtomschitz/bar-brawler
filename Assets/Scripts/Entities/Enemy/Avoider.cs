using UnityEngine;

public class Avoider : MonoBehaviour
{
    public Transform enemy;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.transform;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemy = null;
        }
    }
}
