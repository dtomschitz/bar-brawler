using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public SceneFader sceneFader;

    public void OnEnable()
    {
        Time.timeScale = 0f;
    }

    public void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void OnContinue()
    {
        GameState.instance.SetState(GameStateType.IN_GAME);
    }

    public void OnRetry()
    {
        GameState.instance.SetState(GameStateType.IN_GAME);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        GameState.instance.SetState(GameStateType.IN_GAME);
        sceneFader.FadeTo(menuSceneName);
    }
}
