using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WaveSpawnerState { SPAWNING, WAITING, COUNTING }

public class WaveSpawner : MonoBehaviour
{
    #region Singelton

    public static WaveSpawner instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public delegate void WaveStateUpdate(WaveSpawnerState state);
    public event WaveStateUpdate OnWaveStateUpdate;

    public Transform enemyPrefab;
    public List<SpawnPoint> SpawnPoints { get; protected set; }

    public bool enableWaves = true;
    public float timeBetweenWaves = 31f;

    public Text stateOfGameText;
    //public Text skipCountdownText;

    public WaveSpawnerState state = WaveSpawnerState.COUNTING;

    private int waveIndex = 0;
    public static int rounds = 0;
    private float waveCountdown;
    private float searchCountdown = 1f;

    void Start()
    {
        SpawnPoints = new List<SpawnPoint>(FindObjectsOfType<SpawnPoint>());
        Reset();
    }

    void Update()
    {
        if (state == WaveSpawnerState.WAITING)
        {
            if (IsEnemyAlive) return;
            Reset();
        }

        if (enableWaves)
        {
            if (waveCountdown <= 0f || Input.GetKeyDown(KeyCode.LeftShift))
            {
                waveCountdown = 0f;
       
                if (state != WaveSpawnerState.SPAWNING)
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
        state = WaveSpawnerState.COUNTING;

        SpawnPoints.ForEach(delegate (SpawnPoint spawnPoint)
        {
            spawnPoint.CloseDoor();
        });

        OnWaveStateUpdate?.Invoke(state);
    }

    private IEnumerator SpawnWave()
    {
        waveIndex++;
        rounds++;
        stateOfGameText.text = waveIndex.ToString();
        state = WaveSpawnerState.SPAWNING;
        OnWaveStateUpdate?.Invoke(state);

        for (int i = 0; i < waveIndex * 2; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);

        }

        state = WaveSpawnerState.WAITING;
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
        get { return state == WaveSpawnerState.WAITING || state == WaveSpawnerState.SPAWNING; }
    }
}