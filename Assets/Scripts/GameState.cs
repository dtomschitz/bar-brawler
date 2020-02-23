using System.Collections;
using UnityEngine;

public enum GameStateType
{
    GamePaused,
    GameOver,
    InGame,
    InShop,
    TargetAcquisition
}

/// <summary>
/// Class <c>GameState</c> manages the current game state.
/// </summary>
public class GameState : MonoBehaviour
{
    #region Singelton

    public static GameState instance;

    void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    #endregion;

    public GameStateType State { get; protected set; } = GameStateType.InGame;

    /// <summary>
    /// Sets the new game state and calls the relevant method for displaying and
    /// hiding relevant and irrelevant information.
    /// </summary>
    /// <param name="newState">The new game state to set</param>
    public void SetState(GameStateType newState)
    {
        if (State == newState) return;
        State = newState;

        switch(newState)
        {
            case GameStateType.GamePaused:
                TogglePauseMenu();
                break;

            case GameStateType.GameOver:
                ToggleGameOver();
                break;

            case GameStateType.InGame:
                ToggleIngame();
                break;

            case GameStateType.InShop:
                ToggleShop();
                break;

            case GameStateType.TargetAcquisition:
                ToggleTargetAcquisition();
                break;

        }
    }

    /// <summary>
    /// Toggles the game state <see cref="GameStateType.GamePaused"/> and hides
    /// all unrelevant information.
    /// </summary>
    void TogglePauseMenu()
    {
        Player.instance.controls.IsMovementEnabled = false;
        DisableTargetAcquisition();

        UIManager.instance.SetHUDActive(false, false);
        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetPauseMenuActive(true);
    }

    /// <summary>
    /// Toggles the game state <see cref="GameStateType.GameOver"/> and hides
    /// all unrelevant information.
    /// </summary>
    void ToggleGameOver()
    {
        Player.instance.controls.IsMovementEnabled = false;
        DisableTargetAcquisition();

        UIManager.instance.SetHUDActive(false, false);
        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetPauseMenuActive(false);

        StartCoroutine(OpenGameOverMenu());
    }

    /// <summary>Displays the game over menu.</summary>
    IEnumerator OpenGameOverMenu()
    {
        yield return new WaitForSeconds(3f);
        UIManager.instance.SetGameOverMenuActive(true);
    }

    /// <summary>
    /// Toggles the game state <see cref="GameStateType.InShop"/> and hides all
    /// unrelevant information.
    /// </summary>
    void ToggleShop()
    {
        Player.instance.controls.IsMovementEnabled = false;
        DisableTargetAcquisition();

        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetHUDActive(true, true, false);
        UIManager.instance.SetShopActive(true);

        UIManager.instance.hud.helpInfo.SetWeaponHelpActive(false);
        UIManager.instance.hud.helpInfo.SetTargetHelpActive(false);
    }

    /// <summary>
    /// Disables the game state <see cref="GameStateType.InGame"/> and displays
    /// the game relevant informations.
    /// </summary>
    void ToggleIngame()
    {
        Player.instance.controls.IsMovementEnabled = true;
        DisableTargetAcquisition();

        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetHUDActive(true, true);

        UIManager.instance.hud.helpInfo.SetWeaponHelpActive(true);
        UIManager.instance.hud.helpInfo.SetTargetHelpActive(false);

        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// Toggles the game state <see cref="GameStateType.TargetAcquisition"/>
    /// and hides all unrelevant information.
    /// </summary>
    void ToggleTargetAcquisition()
    {
        UIManager.instance.SetShopActive(false);
        UIManager.instance.SetPauseMenuActive(false);
        UIManager.instance.SetGameOverMenuActive(false);
        UIManager.instance.SetHUDActive(true);

        UIManager.instance.hud.helpInfo.SetWeaponHelpActive(false);
        UIManager.instance.hud.helpInfo.SetTargetHelpActive(true);


        Player.instance.controls.IsMovementEnabled = true;
    }

    /// <summary>Displays the target acquisition if it got enabled.</summary>
    private void DisableTargetAcquisition()
    {
        if (TargetAcquisition.instance.IsEnabled)
        {
            TargetAcquisition.instance.Toggle();
            TargetAcquisition.instance.IsEnabled = false;
        }
    }

    /// <summary>
    /// This method checks if the player is currently in game.
    /// </summary>
    /// <returns>True if the current game state is equals to
    /// <see cref="GameStateType.InGame"/> and <see cref="GameStateType.TargetAcquisition"/>;
    /// otherwise, false.
    /// </returns>
    public bool IsInGame
    {
        get { return State == GameStateType.InGame || State == GameStateType.TargetAcquisition; }
    }

    /// <summary>
    /// This method checks if the player is currently in the shop.
    /// </summary>
    /// <returns>True if the current game state is equals to
    /// <see cref="GameStateType.InShop"/>; otherwise, false.
    /// </returns>
    public bool IsInShop
    {
        get { return State == GameStateType.InShop; }
    }

    /// <summary>
    /// This method checks if the player is currently in target acquisition mode.
    /// </summary>
    /// <returns>True if the current game state is equals to
    /// <see cref="GameStateType.TargetAcquisition"/>; otherwise, false.
    /// </returns>
    public bool IsInTargetAcquisition
    {
        get { return State == GameStateType.TargetAcquisition; }
    }
}