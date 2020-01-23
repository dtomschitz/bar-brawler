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

    public Canvas hudCanvas;
    public Canvas shopCanvas;
    public Canvas gameOverCanvas;

    public PauseMenu pauseMenu;

    public Hotbar hotbar;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public MoneyInfo moneyInfo;
    public WaveInfo waveInfo;
    public InteractionHint interactionHint;

    public GameObject gameOverUI;

    public void SetShopCanvasActive(bool active)
    {
        shopCanvas.gameObject.SetActive(active);
    }

    public void TogglePauseMenuCanvas()
    {
        hudCanvas.gameObject.SetActive(!hudCanvas.gameObject.activeSelf);
        pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);

    }

    public void SetPauseMenuCanvasActive(bool active)
    {
        hudCanvas.gameObject.SetActive(!active);
        pauseMenu.gameObject.SetActive(active);
    }

    public void SetGameOverCanvasActive(bool active)
    {
        gameOverCanvas.gameObject.SetActive(active);
    }

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

    public void DisplayGameOverUI(bool visible)
    {
        DisplayHealthBar(!visible);
        DisplayManaBar(!visible);
        DisplayHotbar(!visible);
        DisplayWaveInfo(!visible);
        DisplayInteractionHint(visible);
        gameOverUI.SetActive(visible);
    }
}
