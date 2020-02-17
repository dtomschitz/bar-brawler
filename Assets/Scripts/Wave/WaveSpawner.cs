namespace Wave
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using static UnityEngine.InputSystem.InputAction;

    /// <summary>
    /// Enum <c>WaveState</c> is used to set the current state of the wave spawner.
    /// <para>
    /// If the current wave state is set to <see cref="WaveState.Spawning"/> the wave spawner is the currently summoning new enemies.
    /// The state <see cref="WaveState.Counting"/> will be used if the wave spawner is currently paused and the countdown for the new wave is displayed.
    /// When the current wave is still ongoing the wave spawner state will be set to <see cref="WaveState.Running"/>.
    /// </para>
    /// </summary>
    public enum WaveState { 
        Spawning, 
        Counting,
        Running 
    }

    /// <summary>
    /// Enum <c>Difficulty</c> is used to define the current wave difficulty. Based on the given wave config the difficulity will be used to summon different enemy types and adjust thier health, strengh and weapons
    /// </summary>
    public enum Difficulty {
        Easy, 
        Medium, 
        Hard 
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

            inputActions.PlayerControls.SkipWave.performed += SkipWaveCountdown;
            inputActions.PlayerControls.SkipWaveDebug.performed += SkipWaveDebug;
        }

        #endregion;

        public delegate void WaveStateUpdate(WaveState state, int rounds);
        public event WaveStateUpdate OnWaveStateUpdate;

        public delegate void WaveCountdownUpdate(float countdown);
        public event WaveCountdownUpdate OnWaveCountdownUpdate;

        [Header("Spawnpoints")]
        public List<SpawnPoint> spawnPoints;

        [Header("Settings")]
        public bool isWaveSpawnerEnabled = true;
        public float timeBetweenWaves = 31f;
        public List<WaveConfig> configs;

        public Text stateOfGameText;

        public WaveState CurrentState { get; protected set; }
        public Difficulty CurrentDifficulty { get; protected set; }
        public WaveConfig CurrentConfig { get; protected set; }

        public int Rounds { get; protected set; }

        private float waveCountdown;
        private float searchCountdown = 1f;

        void Start()
        {
            CurrentState = WaveState.Counting;
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
            if (isWaveSpawnerEnabled && (GameState.instance.State != GameStateType.GameOver || GameState.instance.State != GameStateType.GamePaused))
            {
                if (CurrentState == WaveState.Running)
                {
                    if (IsEnemyAlive) return;
                    Player.instance.animator.OnVictory();
                    ResetWaveSpawner();
                }

                if (waveCountdown <= 0f)
                {
                    waveCountdown = 0f;
                    if (CurrentState != WaveState.Spawning) StartNextWave();

                    return;
                }

                waveCountdown -= Time.deltaTime;
                if (waveCountdown > 0f) OnWaveCountdownUpdate?.Invoke(waveCountdown);
            }
        }


        /// <summary>
        /// Gets called if the user pressed the B button while he is in not in the shop or in target acquisition mode. The countdown for the next wave will then be eventually skipped to 3 seconds.
        /// </summary>
        /// <param name="ctx"></param>
        public void SkipWaveCountdown(CallbackContext ctx)
        {
            if (GameState.instance.IsInTargetAcquisition || GameState.instance.IsInShop || waveCountdown <= 4f) return;
            waveCountdown = 4f;
        }

        public void SkipWaveDebug(CallbackContext ctx)
        {
            /*  GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
              for (var i = 0; i < enemies.Length; i++)
              {
                  Destroy(enemies[i]);
              }*/
        }


        /// <summary>
        /// This method resets the current state to <see cref="WaveState.Counting"/> and the wave countdown to the set initial value.
        /// </summary>
        private void ResetWaveSpawner()
        {
            SetState(WaveState.Counting);
            waveCountdown = timeBetweenWaves;
        }

        /// <summary>
        /// This method starts the next wave. It will add a new round to the <see cref="WaveSpawner.Rounds"/> counter, select the specific config which should be used for the new wave and will summon the new enemies.
        /// </summary>
        private void StartNextWave()
        {
            Rounds++;
            Debug.LogFormat("Spawning Wave (num: {0}, difficulty: {1})", Rounds, CurrentDifficulty);

            WaveConfig waveConfig = SelectCurrentConfig();
            if (waveConfig != null)
            {
                SetConfig(waveConfig);
                StartCoroutine(SpawnRoutine());
                Statistics.instance.AddRound();
            }
        }

        /// <summary>
        /// This method determinants which of the set <see cref="WaveSpawner.configs"/>configs should be used for the current wave and returns it.
        /// </summary>
        /// <returns>The wave config which is intended for the current round number.</returns>
        private WaveConfig SelectCurrentConfig()
        {
            foreach (WaveConfig config in configs)
            {
                if (config != CurrentConfig && config.round == Rounds) return config;
            }
            return null;
        }

        /// <summary>
        /// This method spawns the enemies.
        /// </summary>
        /// <returns></returns>
        private IEnumerator SpawnRoutine()
        {
            SetState(WaveState.Spawning);

            for (int i = 0; i < Rounds * 1.25; i++)
            {
                SpawnPoint spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];


                Enemy enemy = Instantiate(CurrentConfig.enemy, spawnPoint.Position, spawnPoint.Rotation).GetComponent<Enemy>();
                if (enemy != null) enemy.Init(CurrentConfig.enemyConfig);

                yield return new WaitForSeconds(1f);
            }
            SetState(WaveState.Running);
            yield break;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newState"></param>
        private void SetState(WaveState newState)
        {
            switch (newState)
            {
                case WaveState.Counting:
                    break;

                case WaveState.Running:
                    break;

                case WaveState.Spawning:
                    break;
            }

            CurrentState = newState;
            OnWaveStateUpdate?.Invoke(CurrentState, Rounds);
        }

        private void SetConfig(WaveConfig config)
        {
            Debug.LogFormat("Update wave config {0} (round: {1}, difficulty: {2}, enemy: {3}", config, config.round, config.difficulty, config.enemy.name);
            CurrentConfig = config;
            CurrentDifficulty = config.difficulty;
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
            get { return CurrentState == WaveState.Running || CurrentState == WaveState.Spawning; }
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
}