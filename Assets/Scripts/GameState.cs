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
        UIManager.instance.SetHUDActive(false);
        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetPauseMenuActive(true);
    }

    private void ToggleGameOver()
    {
        UIManager.instance.SetHUDActive(false);
        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(true);
    }

    private void ToggleShop()
    {
        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetHUDActive(true);
        UIManager.instance.SetShopActive(true);
    }

    private void ToggleIngame()
    {
        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetHUDActive(true);
    }
}
