using Settings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{ 
    public abstract class SpawnPoint : MonoBehaviour
    {
        [SerializeField] protected GameObject prefab;
        [SerializeField] private Color color;

        public void Spawn(LevelSettings levelSettings)
        {
            var position = transform.position;
            var go = Instantiate(prefab);
            go.transform.position = new Vector3(position.x, position.y, 13.3f);
            AfterSpawn(go, levelSettings);
        }

        protected abstract void AfterSpawn(GameObject go, LevelSettings levelSettings);

        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            Gizmos.DrawCube(transform.position, Vector3.one);
        }
    }
}