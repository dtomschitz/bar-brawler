using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactionHint;
    private bool isInInteraction = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HUDManager.instance.interactionHint.DisplayInteractionHint(interactionHint);
        }
    }

    public virtual void Interact()
    {
        isInInteraction = true;
    }

    public virtual void InteractCanceled()
    {
        isInInteraction = false;
    }

    public bool IsInInteraction => isInInteraction;
}
