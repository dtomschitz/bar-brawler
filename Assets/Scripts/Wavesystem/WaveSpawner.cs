using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SpawnState { SPAWNING, WAITING, COUNTING }

public class WaveSpawner : MonoBehaviour
{
    #region Singelton

    public static WaveSpawner instance;

    void Awake()
    {
        instance = this;
    }

    #endregion;

    public delegate void WaveUpdate(SpawnState state);
    public event WaveUpdate OnWaveUpdate;

    public Transform enemyPrefab;
    public List<SpawnPoint> SpawnPoints { get; protected set; }

    public bool enableWaves = true;
    public float timeBetweenWaves = 31f;

    public Text stateOfGameText;
    public Text skipCountdownText;

    public SpawnState state = SpawnState.COUNTING;

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
        if (state == SpawnState.WAITING)
        {
            if (IsEnemyAlive) return;
            Reset();
        }

        if (enableWaves)
        {
            if (waveCountdown <= 0f || Input.GetKeyDown(KeyCode.LeftShift))
            {
                waveCountdown = 0f;
                skipCountdownText.gameObject.SetActive(false);
                if (state != SpawnState.SPAWNING)
                {
                    StartCoroutine(SpawnWave());
                }
            }
            else
            {
                skipCountdownText.gameObject.SetActive(true);
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
        state = SpawnState.COUNTING;

        SpawnPoints.ForEach(delegate (SpawnPoint spawnPoint)
        {
            spawnPoint.CloseDoor();
        });

        OnWaveUpdate?.Invoke(state);
    }

    private IEnumerator SpawnWave()
    {
        waveIndex++;
        rounds++;
        stateOfGameText.text = waveIndex.ToString();
        state = SpawnState.SPAWNING;
        OnWaveUpdate?.Invoke(state);

        for (int i = 0; i < waveIndex * 2; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);

        }

        state = SpawnState.WAITING;
        OnWaveUpdate?.Invoke(state);
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
        get { return state == SpawnState.WAITING || state == SpawnState.SPAWNING; }
    }
}