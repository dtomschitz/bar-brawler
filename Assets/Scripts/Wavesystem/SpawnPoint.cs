using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
