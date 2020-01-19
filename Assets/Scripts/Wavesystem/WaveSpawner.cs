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

public class WaveSpawner : MonoBehaviour
{
    #region Singelton

    public static WaveSpawner instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public delegate void WaveStateUpdate(WaveState state);
    public event WaveStateUpdate OnWaveStateUpdate;

    public Transform enemyPrefab;

    [Header("Enemies")]
    public GameObject EasyEnemey; 
    public GameObject MediumEnemy; 
    public GameObject HardEnemy;
    private Dictionary<Difficulty, GameObject> enemies = new Dictionary<Difficulty, GameObject>(3);

    public List<SpawnPoint> SpawnPoints { get; protected set; }

    public bool isWaveSpawnerEnabled = true;
    public float timeBetweenWaves = 31f;

    public Text stateOfGameText;

    public WaveState state = WaveState.Counting;
    public Difficulty difficulty = Difficulty.Easy;

    //private int waveIndex = 0;
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
        if (state == WaveState.Running)
        {
            if (IsEnemyAlive) return;
            Reset();
        }

        if (isWaveSpawnerEnabled)
        {
            if (waveCountdown <= 0f || Input.GetKeyDown(KeyCode.LeftShift))
            {
                waveCountdown = 0f;
       
                if (state != WaveState.Spawning)
                {
                    StartCoroutine(SpawnWave());
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
                if (waveCountdown > 0f)
                {
                    stateOfGameText.text = Mathf.Floor(waveCountdown).ToString();
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

        OnWaveStateUpdate?.Invoke(state);
    }

    private IEnumerator SpawnWave()
    {
        // waveIndex++;

        Debug.LogFormat("Spawning Wave (num: {0}, difficulty: {1})", rounds, difficulty);
        rounds++;
        stateOfGameText.text = rounds.ToString();
        state = WaveState.Spawning;
        OnWaveStateUpdate?.Invoke(state);

        for (int i = 0; i < rounds * 2; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);

        }

        state = WaveState.Running;
        OnWaveStateUpdate?.Invoke(state);
        yield break;
    }

    private void SpawnEnemy()
    {
        SpawnPoint spawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
        spawnPoint.OpenDoor();
        Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
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