using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool isInInteraction = false;

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
