using System;
using UnityEngine;
using UnityEngine.UI;
using Wave;

/// <summary>
/// Class <c>WaveInfo</c> manages the visualisation of the wave state text and
/// the wave skip text by subscribing to the <see cref="WaveSpawner.OnWaveStateUpdate"/>
/// and <see cref="WaveSpawner.OnWaveCountdownUpdate"/> events.
/// </summary>
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
        if (waveSpawner == null) throw new ArgumentNullException("WaveSpawner class cannot be null!");

        waveSpawner.OnWaveStateUpdate += OnWaveStateUpdate;
        waveSpawner.OnWaveCountdownUpdate += OnWaveCountdownUpdate;
    }

    /// <summary>
    /// Gets called if the <see cref="WaveSpawner.State"/> got updated. If the
    /// new state is set to <see cref="WaveState.Counting"/> the method will 
    /// display the skip countdown message.
    /// Is the wave ongoing the method will display the amount of rounds the
    /// player reached.
    /// </summary>
    /// <param name="state">The new state</param>
    /// <param name="rounds">The amount of rounds the player survived.</param>
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

    /// <summary>
    /// This method gets called if the <see cref="WaveSpawner.State"/> is set to
    /// <see cref="WaveState.Counting"/> and will update the countdown for the
    /// next approaching wave. 
    /// </summary>
    /// <param name="countdown">The current countdown</param>
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
