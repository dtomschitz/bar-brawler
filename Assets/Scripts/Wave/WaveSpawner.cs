using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Wave
{
    /// <summary>
    /// Enum <c>WaveState</c> is used to set the current state of the wave spawner.
    /// If the current wave state is set to <see cref="WaveState.Spawning"/> the wave spawner is the currently summoning new enemies.
    /// The state <see cref="WaveState.Counting"/> will be used if the wave spawner is currently paused and the countdown for the new wave is displayed.
    /// When the current wave is still ongoing the wave spawner state will be set to <see cref="WaveState.Running"/>.
    /// </summary>
    public enum WaveState { 
        Spawning, 
        Counting,
        Running 
    }

    /// <summary>
    /// Enum <c>Difficulty</c> is used to define the current wave difficulty.
    /// Based on the given wave config the difficulity will be used to summon
    /// different enemy types and adjust thier health, strengh and weapons.
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
            inputActions.PlayerControls.SkipWave.performed += SkipWaveCountdown;
            inputActions.PlayerControls.SkipWaveDebug.performed += SkipWaveDebug;
        }

        #endregion;

        public delegate void WaveStateUpdate(WaveState state, int rounds);
        public event WaveStateUpdate OnWaveStateUpdate;

        public delegate void WaveCountdownUpdate(float countdown);
        public event WaveCountdownUpdate OnWaveCountdownUpdate;

        [Header("Spawnpoints")]
        public SpawnPoint[] spawnPoints;

        [Header("Settings")]
        public bool enableWaveSpawner = true;
        public bool enableDebug = false;
        public float timeBetweenWaves = 31f;
        public WaveConfig[] configs;

        public WaveState State { get; protected set; }
        public Difficulty CurrentDifficulty { get; protected set; }
        public WaveConfig CurrentConfig { get; protected set; }

        public int Rounds { get; protected set; }

        private float waveCountdown;
        private float searchCountdown = 1f;

        void Start()
        {
            State = WaveState.Counting;
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
            if (enableWaveSpawner && (GameState.instance.State != GameStateType.GameOver || GameState.instance.State != GameStateType.GamePaused))
            {
                if (State == WaveState.Running)
                {
                    if (IsEnemyAlive) return;
                    Player.instance.animator.OnVictory();
                    ResetWaveSpawner();
                }

                if (waveCountdown <= 0f)
                {
                    waveCountdown = 0f;
                    if (State != WaveState.Spawning) StartNextWave();
                    return;
                }

                waveCountdown -= Time.deltaTime;
                if (waveCountdown > 0f) OnWaveCountdownUpdate?.Invoke(waveCountdown);
            }
        }


        /// <summary>
        /// Gets called if the user pressed the B button while he is in not in
        /// the shop or in target acquisition mode. The countdown for the next
        /// wave will then be eventually skipped to 3 seconds.
        /// </summary>
        /// <param name="ctx"></param>
        public void SkipWaveCountdown(CallbackContext ctx)
        {
            if (GameState.instance.IsInTargetAcquisition || GameState.instance.IsInShop || waveCountdown <= 4f) return;
            waveCountdown = 4f;
        }

        public void SkipWaveDebug(CallbackContext ctx)
        {
            if (!enableDebug) return;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (var i = 0; i < enemies.Length; i++) Destroy(enemies[i]);
        }


        /// <summary>
        /// This method resets the current state to <see cref="WaveState.Counting"/>
        /// and the wave countdown to the set initial value.
        /// </summary>
        private void ResetWaveSpawner()
        {
            SetState(WaveState.Counting);
            waveCountdown = timeBetweenWaves;
        }

        /// <summary>
        /// This method starts the next wave. It will add a new round to the
        /// <see cref="WaveSpawner.Rounds"/> counter, select the specific config
        /// which should be used for the new wave and will summon the new enemies.
        /// </summary>
        private void StartNextWave()
        {
            WaveConfig nextConfig = GetNextWaveConfig();
            if (nextConfig != null) SetConfig(nextConfig);

            Rounds++;
            Debug.LogFormat("Spawning Wave (num: {0}, difficulty: {1})", Rounds, CurrentDifficulty);

            StartCoroutine(SpawnRoutine());
            Statistics.instance.AddRound();
        }

        /// <summary>
        /// This method determinants which of the set <see cref="WaveSpawner.configs"/>
        /// configs should be used for the next wave and returns it.
        /// </summary>
        /// <returns>The wave config which is intended for the current round number.</returns>
        private WaveConfig GetNextWaveConfig()
        {
            foreach (WaveConfig config in configs)
            {
                if (config.round == Rounds) return config;
            }
            return null;
        }

        /// <summary>
        /// This method spawns the enemies for the current wave. For each enemy
        /// one of the set spawn points will be selected randomly. The new
        /// instantiate enemy will then get the enemy config of the current wave
        /// config in order to create random enemy types.
        /// </summary>
        /// <returns></returns>
        private IEnumerator SpawnRoutine()
        {
            SetState(WaveState.Spawning);

            for (int i = 0; i < Rounds * 1.25; i++)
            {
                SpawnPoint spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];


                Enemy enemy = Instantiate(CurrentConfig.enemy, spawnPoint.Position, spawnPoint.Rotation).GetComponent<Enemy>();
                if (enemy != null) enemy.Init(CurrentConfig.enemyConfig);

                yield return new WaitForSeconds(1f);
            }
            SetState(WaveState.Running);
            yield break;
        }

        /// <summary>
        /// This methods sets the current state to the new one and will fire the
        /// <see cref="OnWaveStateUpdate"/> event in order to provide the new
        /// state to the shop system and certain ui elements.
        /// </summary>
        /// <param name="newState">The new state.</param>
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

            State = newState;
            OnWaveStateUpdate?.Invoke(State, Rounds);
        }

        /// <summary>
        /// This method sets the current <see cref="WaveConfig"/> to the new one
        /// and updates the current difficulty.
        /// </summary>
        /// <param name="config">The new wave config.</param>
        private void SetConfig(WaveConfig config)
        {
            Debug.LogFormat("Update wave config {0} (round: {1}, difficulty: {2}, enemy: {3}", config, config.round, config.difficulty, config.enemy.name);
            CurrentConfig = config;
            CurrentDifficulty = config.difficulty;
        }

        /// <summary>
        /// This method determines whether there is enemies are still alive or
        /// not. This is achieved by searching every set time for game objects
        /// with the enemy tag. If an enemy where found the method returns true;
        /// otherwise false.
        /// </summary>
        private bool IsEnemyAlive
        {
            get
            {
                searchCountdown -= Time.deltaTime;
                if (searchCountdown <= 0f)
                {
                    searchCountdown = 1f;
                    if (GameObject.FindGameObjectWithTag("Enemy") == null) return false;
                }
                return true;
            }
        }

        /// <summary>
        /// This method determines wether a wave is running. This is the case
        /// when the current state is equals to <see cref="WaveState.Running"/>
        /// or <see cref="WaveState.Spawning"/>.
        /// </summary>
        public bool IsWaveRunning
        {
            get { return State == WaveState.Running || State == WaveState.Spawning; }
        }
    }
}