using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    public void Restart()
    {
        WaveSpawner.rounds = 0;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}

