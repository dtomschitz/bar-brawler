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
        SetHUDActive(active, true, true, true);
    }

    public void SetHUDActive(bool active, bool showHelp)
    {
        SetHUDActive(active, true, true, showHelp);
    }

    public void SetHUDActive(bool active, bool showWaveSkipText, bool showWaveCountdown, bool showHelp) {
        hud.gameObject.SetActive(active);

        hud.waveInfo.SetSkipTextActive(showWaveSkipText);
        hud.waveInfo.SetSkipCountdownActive(showWaveCountdown);

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
