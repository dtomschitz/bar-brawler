namespace Wave
{
    using UnityEngine;

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