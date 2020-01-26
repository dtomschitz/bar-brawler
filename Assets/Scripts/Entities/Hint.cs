using UnityEngine;
using UnityEngine.InputSystem;

public class Hint : MonoBehaviour
{
    public string hint;
    public InputAction key;
    public bool isHintVisibleDuringWaves = true;

    private bool isHintEnabled = true;

    /*void Start()
    {
        WaveSpawner.instance.OnWaveStateUpdate += OnWaveStateUpdate;
    }

    void Update()
    {
        /*if (Input.GetKey(key))
        {
            UIManager.instance.hud.interactionHint.HideHint(.2f);
            isHintEnabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isHintEnabled && other.gameObject.tag == "Player")
        {
            UIManager.instance.hud.interactionHint.DisplayHint(hint);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isHintEnabled && other.gameObject.tag == "Player")
        {
           // UIManager.instance.hud.interactionHint.HideHint();
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
    }*/
}
