using UnityEngine;
using UnityEngine.SceneManagement;
using Wave;

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
        GameState.instance.SetState(State.INGAME);
    }

    public void OnRetry()
    {
        GameState.instance.SetState(State.INGAME);
        WaveSpawner.rounds = 0;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        gameObject.SetActive(false);
        sceneFader.FadeTo(menuSceneName);
    }
}
