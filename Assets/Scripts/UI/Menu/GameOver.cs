using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public void Restart()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}

