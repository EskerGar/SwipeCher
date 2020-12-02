using UnityEngine;

namespace Arrow
{
    public class DirectShootArea : IShootArea
    {
        private readonly Vector2 _direction;
        private readonly Vector3 _archerPosition;
        private Vector2 _normalizedDirection;
        private readonly GameObject _arrowDirection;
        private readonly Vector3 _spawnVector;

        public void SpawnArrow(GameObject arrowPrefab)
        {
            var arrow = Object.Instantiate(arrowPrefab);
            arrow.transform.position = _archerPosition + _spawnVector * 1.5f;
            arrow.GetComponent<Rigidbody>().velocity = (_normalizedDirection * 10f);
            // Turning the arrow in the desired direction
            arrow.transform.up = -_normalizedDirection;
        }

        public void ClearArea()
        {
            Object.Destroy(_arrowDirection);
        }

        public DirectShootArea(Vector2 direction, Vector3 archerPosition, GameObject arrowDirectionPrefab)
        {
            _direction = direction;
            _archerPosition = archerPosition;
            FindNormalizedDirection();
            // Normalized direction with Z = 0f
            _spawnVector = new Vector3(_normalizedDirection.x, _normalizedDirection.y);
            _arrowDirection = Object.Instantiate(arrowDirectionPrefab);
            // Z offset
            _arrowDirection.transform.position = _archerPosition + _spawnVector * 2f - new Vector3(0f, 0f, 0.2f);
            // Turning in the desired direction
            _arrowDirection.transform.right = _normalizedDirection;
        }

        private void FindNormalizedDirection()
        {
            _normalizedDirection = (_direction - (Vector2)_archerPosition).normalized;
        }
    }
}