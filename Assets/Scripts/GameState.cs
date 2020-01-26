using UnityEngine;

public enum State
{
    GAME_PAUSED,
    GAME_OVER,
    INGAME,
    IN_SHOP,
    TARGET_ACQUISITION
}


public class GameState : MonoBehaviour
{
    #region Singelton

    public static GameState instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public State state = State.INGAME;

    public void SetState(State newState)
    {
        if (state == newState) return;
        state = newState;

        switch(newState)
        {
            case State.GAME_PAUSED:
                TogglePauseMenu();
                break;

            case State.GAME_OVER:
                ToggleGameOver();
                break;

            case State.INGAME:
                ToggleIngame();
                break;

            case State.IN_SHOP:
                ToggleShop();
                break;

            case State.TARGET_ACQUISITION:
                ToggleTargetAcquisition();
                break;

        }
    }

    private void TogglePauseMenu()
    {
        Player.instance.controls.IsMovementEnabled = false;
        DisableTargetAcquisition();

        UIManager.instance.SetHUDActive(false, false);
        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetPauseMenuActive(true);
    }

    private void ToggleGameOver()
    {
        Player.instance.controls.IsMovementEnabled = false;
        DisableTargetAcquisition();

        UIManager.instance.SetHUDActive(false, false);
        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(true);
    }

    private void ToggleShop()
    {
        Player.instance.controls.IsMovementEnabled = false;
        DisableTargetAcquisition();

        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetHUDActive(true, false, true, false);
        UIManager.instance.SetShopActive(true);
    }

    private void ToggleIngame()
    {
        Player.instance.controls.IsMovementEnabled = true;
        DisableTargetAcquisition();

        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetHUDActive(true, true);

        Time.timeScale = 1.0f;
    }

    private void ToggleTargetAcquisition()
    {
        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetHUDActive(true, false);

        Player.instance.controls.IsMovementEnabled = true;

        //TargetAcquisition.instance.Toggle();
    }

    private void DisableTargetAcquisition()
    {
        if (TargetAcquisition.instance.IsEnabled)
        {
            TargetAcquisition.instance.Toggle();
            TargetAcquisition.instance.IsEnabled = false;
        }
    }

    public bool IsInGame
    {
        get { return state == State.INGAME ||state == State.TARGET_ACQUISITION; }
    }
}
