using UnityEngine;
using UnityEngine.SceneManagement;
using Wave;

public class GameOver : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    public void Restart()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}

