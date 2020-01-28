using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public enum WaveState { Spawning, Counting, Running }
public enum Difficulty { Easy, Medium, Hard }

[System.Serializable]
public class WaveConfig
{
    public int round;
    public Difficulty difficulty;
    public GameObject enemy;
}


public class WaveSpawner : MonoBehaviour
{
    #region Singelton

    public static WaveSpawner instance;

    private PlayerInputActions inputActions;

    void Awake()
    {
        instance = this;

        inputActions = new PlayerInputActions();
        //inputActions.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        //inputActions.PlayerControls.Rotation.performed += ctx => lookPosition = ctx.ReadValue<Vector2>();

        inputActions.PlayerControls.SkipWave.performed += SkipWave;
    }

    #endregion;

    public delegate void WaveStateUpdate(WaveState state, int rounds);
    public event WaveStateUpdate OnWaveStateUpdate;

    [Header("Enemies")]
    public GameObject EasyEnemey; 
    public GameObject MediumEnemy; 
    public GameObject HardEnemy;

    [Header("Spawnpoints")]
    public List<SpawnPoint> spawnPoints;

    [Header("Settings")]
    public bool isWaveSpawnerEnabled = true;
    public float timeBetweenWaves = 31f;
    public List<WaveConfig> configs;

    public Text stateOfGameText;

    public WaveState currentState { get; protected set; }
    public Difficulty currentDifficulty { get; protected set; }
    public WaveConfig currentConfig { get; protected set; }

    public static int rounds = 0;
    private float waveCountdown;
    private float searchCountdown = 1f;

    private float randomSpawnDigit;

    void Start()
    {
        currentState = WaveState.Counting;
        ResetWaveSpawner();
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }


    void Update()
    {
        if (isWaveSpawnerEnabled && (GameState.instance.state != State.GAME_OVER || GameState.instance.state != State.GAME_PAUSED))
        {
            if (currentState == WaveState.Running)
            {
                if (IsEnemyAlive) return;
                ResetWaveSpawner();
            }

            if (waveCountdown <= 0f)
            {
                waveCountdown = 0f;
                if (currentState != WaveState.Spawning)
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

    public void SkipWave(CallbackContext ctx)
    {
        if (GameState.instance.IsInTargetAcquisition || GameState.instance.IsInShop) return;
        waveCountdown = 3f;
    }


    private void ResetWaveSpawner()
    {
        waveCountdown = timeBetweenWaves;
        currentState = WaveState.Counting;
        OnWaveStateUpdate?.Invoke(currentState, rounds);

        /*for ()
        spawnPoints.ForEach(delegate (SpawnPoint spawnPoint)
        {
            spawnPoint.CloseDoor();
        });*/
    }

    private void StartWave()
    {
        rounds++;
        SelectCurrentConfig();

        Debug.LogFormat("Spawning Wave (num: {0}, difficulty: {1})", rounds, currentDifficulty);
   
        currentState = WaveState.Spawning;
        OnWaveStateUpdate?.Invoke(currentState, rounds);
        //spawnPoint.OpenDoor();

        SpawnEnemies();

        currentState = WaveState.Running;
        OnWaveStateUpdate?.Invoke(currentState, rounds);

    }

    private void SelectCurrentConfig()
    {
        /*if (rounds >= 5 && rounds <= 9)
        {
            difficulty = Difficulty.Medium;
        }

        if (rounds >= 10)
        {
            difficulty = Difficulty.Hard;
        }

        return;*/

        foreach (WaveConfig config in configs)
        {
            if (config != currentConfig && config.round == rounds)
            {
                SetConfig(config);
                return;
            }
        }
    }

    private void SpawnEnemies()
    {
        SpawnPoint spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        if (currentConfig != null && currentConfig.enemy != null)
        {

            Debug.Log("Spawnin Enemies");
            StartCoroutine(SpawnRoutine(spawnPoint.transform));
        }
    }

    private IEnumerator SpawnRoutine(Transform spawnPoint)
    {
        for (int i = 0; i < rounds * 1.25; i++)
        {
            //whichEnemy(spawnPoint);
            Instantiate(currentConfig.enemy, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }

    private void SetConfig(WaveConfig config)
    {
        currentConfig = config;
        currentDifficulty = config.difficulty;
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
        get { return currentState == WaveState.Running || currentState == WaveState.Spawning; }
    }

   /* private void whichEnemy(Transform spawnPoint)
    {

        if (currentDifficulty == Difficulty.Easy)
        {
            SpawnEnemy(EasyEnemey, spawnPoint);
        }

        if (currentDifficulty == Difficulty.Medium)
        {
            mediumSpawningAlgorithm(spawnPoint);
        }

        if (currentDifficulty == Difficulty.Hard)
        {
            hardSpawningAlgorithm(spawnPoint);
        }
    }

    private void mediumSpawningAlgorithm(Transform spawnPoint)
    {
        randomSpawnDigit = Random.value * 100f;

        if (randomSpawnDigit < 75)
        {
            SpawnEnemy(EasyEnemey, spawnPoint);
        }


        if (randomSpawnDigit > 74) 
        {
            SpawnEnemy(MediumEnemy, spawnPoint);
        }

    }

    private void hardSpawningAlgorithm(Transform spawnPoint)
    {
        randomSpawnDigit = Random.value * 100f;

        if (randomSpawnDigit < 50)
        {
            SpawnEnemy(EasyEnemey, spawnPoint);
        }

        if (randomSpawnDigit > 49 &&  randomSpawnDigit < 85)
        {
            SpawnEnemy(MediumEnemy, spawnPoint);
        }

        if (randomSpawnDigit > 84) 
        {
            SpawnEnemy(HardEnemy, spawnPoint);
        }

    }*/

}