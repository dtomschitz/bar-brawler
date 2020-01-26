using UnityEngine;

public enum State
{
    GAME_PAUSED,
    GAME_OVER,
    INGAME,
    IN_SHOP,
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
        }
    }

    private void TogglePauseMenu()
    {
        Player.instance.controls.IsMovementEnabled = false;
        ToggleCrosshair();

        UIManager.instance.SetHUDActive(false, false);
        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetPauseMenuActive(true);
    }

    private void ToggleGameOver()
    {
        Player.instance.controls.IsMovementEnabled = false;
        ToggleCrosshair();

        UIManager.instance.SetHUDActive(false, false);
        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(true);
    }

    private void ToggleShop()
    {
        Player.instance.controls.IsMovementEnabled = false;
        ToggleCrosshair();

        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetHUDActive(true, false);
        UIManager.instance.SetShopActive(true);
    }

    private void ToggleIngame()
    {
        Player.instance.controls.IsMovementEnabled = true;
        ToggleCrosshair();

        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetHUDActive(true, true);
    }

    private void ToggleCrosshair()
    {
        if (TargetAcquisition.instance.IsEnabled)
        {
            TargetAcquisition.instance.Toggle();
            TargetAcquisition.instance.IsEnabled = false;
        }
    }

    public bool IsInGame
    {
        get { return state == State.INGAME; }
    }
}
