using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Settings/LevelSettings", fileName = "LevelSettings")]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField] private float archerSpeed;
        [SerializeField] private float enemySpeed;
        [SerializeField] private float enemyAttackDelay;
        [SerializeField] private float enemySpawnDelay;
        [SerializeField] private float barriersSpawnDelay;

        public float ArcherSpeed => archerSpeed;

        public float EnemySpawnDelay => enemySpawnDelay;

        public float EnemyAttackDelay => enemyAttackDelay;

        public float BarriersSpawnDelay => barriersSpawnDelay;

        public float EnemySpeed => enemySpeed;
    }
}
