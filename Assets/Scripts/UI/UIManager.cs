using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singelton

    public static UIManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public HUDManager hud;
    public Canvas shopCanvas;
    public Canvas gameOverCanvas;
    public PauseMenu pauseMenu;
    public GameObject gameOverUI;

    public void SetHUDActive(bool active)
    {
        SetHUDActive(active, true, true, true, true, true);
    }

    public void SetHUDActive(bool active, bool showHelp)
    {
        SetHUDActive(active, true, true, showHelp);
    }

    public void SetHUDActive(bool active, bool showWaveCountdown, bool showWaveSkipText)
    {
        SetHUDActive(active, showWaveCountdown, showWaveSkipText, true, true, true);
    }

    public void SetHUDActive(bool active, bool showWaveCountdown = true, bool showWaveSkipText = true, bool showHealthBar = true, bool showManaBar = true, bool showHelp = true)
    {
        hud.gameObject.SetActive(active);

        hud.waveInfo.SetSkipTextActive(showWaveSkipText);
        hud.waveInfo.SetSkipCountdownActive(showWaveCountdown);

        hud.healthBar.gameObject.SetActive(showHealthBar);
        hud.manaBar.gameObject.SetActive(showManaBar);

        hud.hotbar.SetLeftBumperActive(showHelp);
        hud.hotbar.SetRightBumperActive(showHelp);
    }

    public void SetShopActive(bool active)
    {
        shopCanvas.gameObject.SetActive(active);
    }

    public void SetPauseMenuActive(bool active)
    {
        pauseMenu.gameObject.SetActive(active);
    }

    public void SetGameOverMenuActive(bool active)
    {
        gameOverCanvas.gameObject.SetActive(active);
    }
}
