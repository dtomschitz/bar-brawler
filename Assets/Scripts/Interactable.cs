using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    public Transform interaction;

    bool isFocused = false;
    bool hasInteracted = false;
    Transform player;

    void Update()
    {
        if (isFocused)
        {
            float distance = Vector3.Distance(player.position, interaction.position);
            if (distance <= radius)
            {
                if (!hasInteracted)
                {
                    hasInteracted = true;
                    Interact();
                }
            } else
            {
                OnUnfocused();
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        hasInteracted = false;
        player = playerTransform;
    }

    public void OnUnfocused()
    {
        isFocused = false;
        hasInteracted = false;
        player = null;
    }

    // Should be overwritten whenever the Class is used somewhere else
    public virtual void Interact()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(interaction.position, radius);
    }
}
