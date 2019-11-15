using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityInteraction : Interactable
{
    bool isFocused = false;
    bool hasInteracted = false;
    Transform player;

    public void OnCollisionEnter(Collision collision)
    {
        if (isFocused)
        {
            float distance = Vector3.Distance(player.position, gameObject.transform.position);
            if (distance <= radius)
            {
                if (!hasInteracted)
                {
                    hasInteracted = true;
                    Interact();
                }
            }
            else
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
}
