namespace Wave
{
    using UnityEngine;

    /// <summary>
    /// Object<c> WaveConfig</c> represents a config file for one or more waves. The config will be loaded if the current number of played rounds is equals to the set round.
    /// </summary>
    [CreateAssetMenu(fileName = "New Wave Config", menuName = "Configs/Wave Config")]
    public class WaveConfig : ScriptableObject
    {
        public int round;
        public Difficulty difficulty;
        public GameObject enemy;

        [Header("Enemy Config")]
        public EnemyConfig enemyConfig;
    }
}