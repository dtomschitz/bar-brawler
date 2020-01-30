using UnityEngine;
using UnityEngine.UI;
using Wave;

public class WaveInfo : MonoBehaviour
{
    public Text stateOfGameText;
    public Text skipCountdownText;

    public Color defaultColor;
    public Color warningColor;
    public float nextRoundWarning;

    void Start()
    {
        WaveSpawner waveSpawner = WaveSpawner.instance;
        if (waveSpawner != null)
        {
            waveSpawner.OnWaveStateUpdate += OnWaveStateUpdate;
            waveSpawner.OnWaveCountdownUpdate += OnWaveCountdownUpdate;
        }
    }

    public void OnWaveStateUpdate(WaveState state, int rounds)
    {
        if (state == WaveState.Counting)
        {
            skipCountdownText.gameObject.SetActive(true);
        }

        if (WaveSpawner.instance.IsWaveRunning)
        {
            skipCountdownText.gameObject.SetActive(false);

            stateOfGameText.color = defaultColor;
            stateOfGameText.text = string.Format("RUNDE {0}", rounds.ToString());
        }
    }

    public void OnWaveCountdownUpdate(float countdown)
    {
        if (countdown <= nextRoundWarning)
        {
            skipCountdownText.gameObject.SetActive(false);
            stateOfGameText.color = warningColor;
        } else
        {
            stateOfGameText.color = defaultColor;
        }

        stateOfGameText.text = string.Format("NÄCHSTE RUNDE IN {0}s", Mathf.Floor(countdown).ToString());
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
