using Settings;
using UnityEngine;

namespace Spawn
{
    public class EnemySpawnPoint : SpawnPoint
    {
        protected override void AfterSpawn(GameObject go, LevelSettings levelSettings)
        {
            go.GetComponent<EnemyBehaviour>().Initialize(levelSettings.EnemyAttackDelay, levelSettings.EnemySpeed);
        }
    }
}