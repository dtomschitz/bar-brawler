using System;
using UnityEngine;

/// <summary>
/// Class HUDManager is used to centralize all management classes of visual
/// relevant informations the player can see  in the Hud.
/// </summary>
public class HUDManager : MonoBehaviour
{
    public Hotbar hotbar;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public MoneyInfo moneyInfo;
    public WaveInfo waveInfo;
    public InteractionHint interactionHint;
    public HelpInfo helpInfo;

    void Start()
    {
        if (hotbar == null) throw new NullReferenceException("Hotbar class cannot be null");
        if (healthBar == null) throw new NullReferenceException("HealthBar class cannot be null");
        if (manaBar == null) throw new NullReferenceException("ManaBar class cannot be null");
        if (moneyInfo == null) throw new NullReferenceException("MoneyInfo class cannot be null");
        if (waveInfo == null) throw new NullReferenceException("WaveInfo class cannot be null");
        if (interactionHint == null) throw new NullReferenceException("InteractionHint class cannot be null");
        if (helpInfo == null) throw new NullReferenceException("HelpInfo class cannot be null");
    }

    /// <summary>
    /// Displays or hides the hotbar in the Hud.
    /// </summary>
    /// <param name="active"></param>
    public void DisplayHotbar(bool active) =>  hotbar.gameObject.SetActive(active);

    /// <summary>
    /// Displays or hides the health bar in the Hud.
    /// </summary>
    /// <param name="active"></param>
    public void DisplayHealthBar(bool active) => healthBar.gameObject.SetActive(active);

    /// <summary>
    /// Displays or hides the mana bar in the Hud.
    /// </summary>
    /// <param name="active"></param>
    public void DisplayManaBar(bool active) => manaBar.gameObject.SetActive(active);

    /// <summary>
    /// Displays or hides the wave informationen in the Hud
    /// </summary>
    /// <param name="active"></param>
    public void DisplayWaveInfo(bool active) => waveInfo.gameObject.SetActive(active);

    /// <summary>
    /// Displays or hides the interactions hints in the Hud.
    /// </summary>
    /// <param name="active"></param>
    public void DisplayInteractionHint(bool active) => interactionHint.gameObject.SetActive(active);
}
