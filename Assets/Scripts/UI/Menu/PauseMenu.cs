using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public SceneFader sceneFader;

    void Start()
    {
        Player.instance.controls.OnPauseGame += OnPauseGame;
    }

    private void OnPauseGame()
    {
        TogglePauseMenu();
    }

    private void TogglePauseMenu()
    {
        UIManager.instance.SetPauseMenuCanvasActive(true);

        if (gameObject.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void OnContinue()
    {
        TogglePauseMenu();
    }

    public void OnRetry()
    {
        TogglePauseMenu();
        WaveSpawner.rounds = 0;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        TogglePauseMenu();
        sceneFader.FadeTo(menuSceneName);
    }
}
