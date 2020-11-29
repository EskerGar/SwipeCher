using Settings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{ 
    public abstract class SpawnPoint : MonoBehaviour
    {
        [SerializeField] protected GameObject prefab;
        [SerializeField] private Color color;
        [SerializeField] protected float spawnRadius = 3f;

        public void Spawn(LevelSettings levelSettings)
        {
            var position = transform.position;
            var randomSpot = new Vector2(Random.Range(position.x - spawnRadius, position.x + spawnRadius), 
                Random.Range(position.y - spawnRadius, position.y + spawnRadius));
            var go = Instantiate(prefab);
            go.transform.position = new Vector3(randomSpot.x, randomSpot.y, 13.3f);
            AfterSpawn(go, levelSettings);
        }

        protected abstract void AfterSpawn(GameObject go, LevelSettings levelSettings);

        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            var position = transform.position;
            Gizmos.DrawCube(position, Vector3.one);
            Gizmos.DrawWireSphere(position, spawnRadius);
        }
    }
}