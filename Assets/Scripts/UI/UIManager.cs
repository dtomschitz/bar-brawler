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

    public void SetHUDActive(bool active, bool ignore = true)
    {
        SetHUDActive(active, true, true, true, true, ignore);
    }

    public void SetHUDActive(bool active, bool showStatsBar, bool ignore = true)
    {
        SetHUDActive(active, true, true, showStatsBar, showStatsBar, ignore);
    }

    public void SetHUDActive(bool active, bool showStatsBar, bool showHelp, bool ignore = true)
    {
        SetHUDActive(active, true, true, showStatsBar, showHelp, ignore);
    }

    public void SetHUDActive(bool active, bool showWaveSkipText, bool showWaveCountdown, bool showStatsBar, bool showHelp, bool ignore = true)
    {
        hud.gameObject.SetActive(active);

        if (!ignore)
        {
            hud.waveInfo.SetSkipTextActive(showWaveSkipText);
            hud.waveInfo.SetSkipCountdownActive(showWaveCountdown);
        }

        hud.healthBar.gameObject.SetActive(showStatsBar);
        hud.manaBar.gameObject.SetActive(showStatsBar);

        hud.hotbar.SetLeftBumperActive(showHelp);
        hud.hotbar.SetRightBumperActive(showHelp);
    }

    public void SetShopActive(bool active) => shopCanvas.gameObject.SetActive(active);

    public void SetPauseMenuActive(bool active) => pauseMenu.gameObject.SetActive(active);

    public void SetGameOverMenuActive(bool active) => gameOverCanvas.gameObject.SetActive(active);

    public void DisplayGameOverUI(bool visible)
    {
        //DisplayHealthBar(!visible);
       // DisplayManaBar(!visible);
        //DisplayHotbar(!visible);
       // DisplayWaveInfo(!visible);
        //DisplayInteractionHint(visible);
        gameOverUI.SetActive(visible);
    }
}
