using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveInfo : MonoBehaviour
{
    public Text stateOfGameText;
    public Text skipCountdownText;

    void Start()
    {
        WaveSpawner.instance.OnWaveStateUpdate += OnWaveStateUpdate;
    }

    public void OnWaveStateUpdate(WaveSpawnerState state)
    {
        if (!WaveSpawner.instance.IsWaveRunning)
        {
            skipCountdownText.gameObject.SetActive(true);
        } else
        {
            skipCountdownText.gameObject.SetActive(false);
        }
    }


    public void DisplaySkipText(bool visible)
    {
        skipCountdownText.gameObject.SetActive(visible);
    }
}
