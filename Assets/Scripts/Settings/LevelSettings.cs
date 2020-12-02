using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Settings/LevelSettings", fileName = "LevelSettings")]
    public class LevelSettings : ScriptableObject
    {
        [Tooltip("Archer move speed")][SerializeField] private float archerSpeed;
        [Tooltip("Enemy move speed")][SerializeField] private float enemySpeed;
        [SerializeField] private float enemyAttackDelay;
        [SerializeField] private float enemySpawnDelay;
        [SerializeField] private float barriersSpawnDelay;

        public float ArcherSpeed
        {
            get => archerSpeed;
            set => archerSpeed = value;
        }

        public float EnemySpawnDelay
        {
            get => enemySpawnDelay;
            set => enemySpawnDelay = value;
        }

        public float EnemyAttackDelay
        {
            get => enemyAttackDelay;
            set => enemyAttackDelay = value;
        }

        public float BarriersSpawnDelay
        {
            get => barriersSpawnDelay;
            set => barriersSpawnDelay = value;
        }

        public float EnemySpeed
        {
            get => enemySpeed;
            set => enemySpeed = value;
        }
    }
}
