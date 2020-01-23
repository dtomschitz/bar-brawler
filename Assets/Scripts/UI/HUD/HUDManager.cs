using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public Hotbar hotbar;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public MoneyInfo moneyInfo;
    public WaveInfo waveInfo;
    public InteractionHint interactionHint;

    public void DisplayHotbar(bool visible)
    {
        hotbar.GetComponentInParent<Canvas>().gameObject.SetActive(visible);
    }

    public void DisplayHealthBar(bool visible)
    {
        healthBar.gameObject.SetActive(visible);
    }

    public void DisplayManaBar(bool visible)
    {
        manaBar.gameObject.SetActive(visible);
    }

    public void DisplayWaveInfo(bool visible)
    {
        waveInfo.gameObject.SetActive(visible);
    }

    public void DisplayInteractionHint(bool visible)
    {
        interactionHint.gameObject.SetActive(visible);
    }
}
