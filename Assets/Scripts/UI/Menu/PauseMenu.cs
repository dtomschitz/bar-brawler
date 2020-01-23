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
        gameObject.SetActive(false);
    }

    public void OnRetry()
    {
        gameObject.SetActive(false);
        WaveSpawner.rounds = 0;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        gameObject.SetActive(false);
        sceneFader.FadeTo(menuSceneName);
    }
}
