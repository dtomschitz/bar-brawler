using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public ParticleSystem flash;

    public void Play()
    {
        flash.Play();
    }
}
