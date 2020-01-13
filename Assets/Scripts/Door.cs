using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsDoorOpen { get; private set; }

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        IsDoorOpen = false;
    }

    public void OpenDoor()
    {
        if (IsDoorOpen) return;

        animator.SetBool("open", true);
    }

    public void CloseDoor()
    {
        if (!IsDoorOpen) return;
        animator.SetBool("open", false);

    }
}
