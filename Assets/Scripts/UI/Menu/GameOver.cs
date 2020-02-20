using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class <c>GameOver</c> is used to display the game over screen when the player
/// died. From here the play could either restart the game or go back to the main
/// menu.
/// </summary>
public class GameOver : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public SceneFader sceneFader;

    public Statistics statistics;

    public GameObject statisticsPanel;
    public Text rounds;
    public Text kills;
    public Text damage;
    public Text money;

    void Start()
    {
        if (statistics == null) statisticsPanel.SetActive(false);

        rounds.text = statistics.SurvivedRounds.ToString();
        kills.text = statistics.Kills.ToString();
        damage.text = statistics.DamageCaused.ToString();
        money.text = "$" + statistics.SpendMoney.ToString();
    }

    /// <summary>
    /// Restarts the game by reloading the main level.
    /// </summary>
    public void Restart()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Fades back to the main menu scene.
    /// </summary>
    public void ExitToMainMenu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}

