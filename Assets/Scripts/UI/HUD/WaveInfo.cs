using UnityEngine;
using UnityEngine.UI;
using Wave;

public class WaveInfo : MonoBehaviour
{
    public Text stateOfGameText;
    public Text skipCountdownText;

    void Start()
    {
        WaveSpawner.instance.OnWaveStateUpdate += OnWaveStateUpdate;
    }

    public void OnWaveStateUpdate(WaveState state, int rounds)
    {
        if (state == WaveState.Counting)
        {
            skipCountdownText.gameObject.SetActive(true);
        } else
        {
            skipCountdownText.gameObject.SetActive(false);
        }

        if (WaveSpawner.instance.IsWaveRunning)
        {
            stateOfGameText.text = string.Format("Runde {0}", rounds.ToString());
        }
    }

    public void SetSkipTextActive(bool active)
    {
        skipCountdownText.gameObject.SetActive(active);
    }

    public void SetSkipCountdownActive(bool active)
    {
        stateOfGameText.gameObject.SetActive(active);
    }


    public void DisplayOnlySkipText(bool visible)
    {
        stateOfGameText.gameObject.SetActive(visible);
        skipCountdownText.gameObject.SetActive(false);
    }

    public void DisplayAll(bool visible)
    {
        stateOfGameText.gameObject.SetActive(visible);
        skipCountdownText.gameObject.SetActive(visible);
    }
}
