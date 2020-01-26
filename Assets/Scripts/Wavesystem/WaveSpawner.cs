using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WaveState { Spawning, Counting, Running }

public enum Difficulty
{
    Easy,
    Medium,
    Hard,
}

[System.Serializable]
public struct WaveConfig
{
    public int fromRoundX;
    public Difficulty difficulty;

    public int minMediumEnemies;
    public int maxMediumEnemies;

    public int minHardEnemies;
    public int maxHardEnemies;
}

public class WaveSpawner : MonoBehaviour
{
    #region Singelton

    public static WaveSpawner instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public delegate void WaveStateUpdate(WaveState state, int rounds);
    public event WaveStateUpdate OnWaveStateUpdate;

    public Transform enemyPrefab;

    [Header("Enemies")]
    public GameObject EasyEnemey; 
    public GameObject MediumEnemy; 
    public GameObject HardEnemy;

    public WaveConfig[] waveConfigs;
    private WaveConfig currentWaveConfig;

    public Dictionary<Difficulty, GameObject> enemies = new Dictionary<Difficulty, GameObject>(3);

    public List<SpawnPoint> SpawnPoints { get; protected set; }

    public bool isWaveSpawnerEnabled = true;
    public float timeBetweenWaves = 31f;

    public Text stateOfGameText;

    public WaveState state = WaveState.Counting;
    public Difficulty difficulty = Difficulty.Easy;

    public static int rounds = 0;
    private float waveCountdown;
    private float searchCountdown = 1f;

    void Start()
    {
        SpawnPoints = new List<SpawnPoint>(FindObjectsOfType<SpawnPoint>());

        enemies.Add(Difficulty.Easy, EasyEnemey);
        enemies.Add(Difficulty.Medium, MediumEnemy);
        enemies.Add(Difficulty.Hard, HardEnemy);

        Reset();
    }

    void Update()
    {
        if (isWaveSpawnerEnabled && (GameState.instance.state != State.GAME_OVER || GameState.instance.state != State.GAME_PAUSED))
        {
            if (state == WaveState.Running)
            {
                if (IsEnemyAlive) return;
                Reset();
            }

            if (waveCountdown <= 0f || Input.GetKeyDown(KeyCode.LeftShift))
            {
                waveCountdown = 0f;
                if (state != WaveState.Spawning)
                {
                    StartWave();
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
                if (waveCountdown > 0f)
                {
                    stateOfGameText.text = string.Format("NEXT ROUND STARTS IN {0}s", Mathf.Floor(waveCountdown).ToString());
                }
            }
        }
    }

    private void Reset()
    {
        waveCountdown = timeBetweenWaves;
        state = WaveState.Counting;

        SpawnPoints.ForEach(delegate (SpawnPoint spawnPoint)
        {
            spawnPoint.CloseDoor();
        });

        OnWaveStateUpdate?.Invoke(state, rounds);
    }

    private void StartWave()
    {
        rounds++;

        Debug.LogFormat("Spawning Wave (num: {0}, difficulty: {1})", rounds, difficulty);
       
        //stateOfGameText.text = rounds.ToString();

        currentWaveConfig = GetCurrentWaveConfig;
        state = WaveState.Spawning;
        OnWaveStateUpdate?.Invoke(state, rounds);

        SpawnPoint spawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
        spawnPoint.OpenDoor();

        StartCoroutine(SpawnEasyEnemies(spawnPoint.transform));

        state = WaveState.Running;
        OnWaveStateUpdate?.Invoke(state, rounds);

    }

    private IEnumerator SpawnEasyEnemies(Transform spawnPoint)
    {
        for (int i = 0; i < rounds * 1.25; i++)
        {
            SpawnEnemy(EasyEnemey, spawnPoint);
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }

    private IEnumerator SpawnMediumEnemies(Transform spawnPoint)
    {
        yield break;
    }

    private IEnumerator SpawnHardEnemies(Transform spawnPoint)
    {
        yield break;
    }

    private void SpawnEnemy(GameObject enemy, Transform spawnPoint)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    private WaveConfig GetCurrentWaveConfig
    {
        get
        {
            foreach (WaveConfig waveConfig in waveConfigs)
            {
                if (waveConfig.difficulty == difficulty) return waveConfig;
            }

            return currentWaveConfig;
        }
    }

    private bool IsEnemyAlive
    {
        get
        {
            searchCountdown -= Time.deltaTime;
            if (searchCountdown <= 0f)
            {
                searchCountdown = 1f;
                if (GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public bool IsWaveRunning
    {
        get { return state == WaveState.Running || state == WaveState.Spawning; }
    }
}