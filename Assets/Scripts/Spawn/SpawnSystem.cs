using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
        public class SpawnSystem : MonoBehaviour
        {
                [SerializeField] private List<EnemySpawnPoint> enemySpawnPoints;
                [SerializeField] private List<BarrierSpawnPoint> barrierSpawnPoints;
                [SerializeField] private LevelSettings levelSettings;

                // Spawn only for object with SpawnPoint class
                private IEnumerator SpawnOnRandomSpawnPoint<T>(float delay, IReadOnlyList<T> spawnPoints)
                        where T : SpawnPoint
                {
                        if (spawnPoints.Count <= 0) yield break;
                        while (true)
                        {
                                yield return new WaitForSeconds(delay);
                                spawnPoints[Random.Range(0, spawnPoints.Count)].Spawn(levelSettings);     
                        }
                }

                private void StartSpawnEnemy() => StartCoroutine(SpawnOnRandomSpawnPoint(levelSettings.EnemySpawnDelay, enemySpawnPoints));

                private void StartSpawnBarrier() =>
                        StartCoroutine(SpawnOnRandomSpawnPoint(levelSettings.BarriersSpawnDelay, barrierSpawnPoints));

                private void Start()
                {
                        StartSpawnEnemy();
                        StartSpawnBarrier();
                }

                private void OnDrawGizmos()
                {
                        Gizmos.color = Color.black;
                        Gizmos.DrawCube(transform.position, Vector3.one);
                } 
        }
}