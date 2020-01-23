using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public string hint;
    public KeyCode key;
    public bool isHintVisibleDuringWaves = true;

    private bool isHintEnabled = true;

    void Start()
    {
        WaveSpawner.instance.OnWaveStateUpdate += OnWaveStateUpdate;
    }

    void Update()
    {
        if (Input.GetKey(key))
        {
            UIManager.instance.interactionHint.HideHint(.2f);
            isHintEnabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isHintEnabled && other.tag == "Player")
        {
            UIManager.instance.interactionHint.DisplayHint(hint);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isHintEnabled && other.tag == "Player")
        {
            UIManager.instance.interactionHint.HideHint();
            isHintEnabled = true;
        }
    }

    public void OnWaveStateUpdate(WaveState state, int rounds)
    {
        if (WaveSpawner.instance.IsWaveRunning && !isHintVisibleDuringWaves)
        {
            isHintEnabled = false;
        } else
        {
            isHintEnabled = true;
        }
    }
}
