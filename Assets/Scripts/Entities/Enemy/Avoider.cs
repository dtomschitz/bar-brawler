using UnityEngine;

public class Avoider : MonoBehaviour
{
    public Transform enemy;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            enemy = collider.transform;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            enemy = null;
        }
    }
}