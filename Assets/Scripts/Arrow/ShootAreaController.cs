using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrow
{
    public class ShootAreaController : MonoBehaviour
    {
        [SerializeField] private GameObject arrowPrefab;
        [SerializeField] private GameObject arrowDirectionPrefab;
        
        
        private readonly List<IShootArea> _shootAreas = new List<IShootArea>();
        private Vector3 _archerPosition;
        private float _delayBetweenShot;
        private Coroutine _shootingCoroutine;

        public void Initialize(float delayBetweenShot)
        {
            _delayBetweenShot = delayBetweenShot;
        }
    
        public void AddArea(Vector2 direction)
        {
            // Create new shoot area
            _shootAreas.Add(new DirectShootArea(direction, _archerPosition, arrowDirectionPrefab));
            if(_shootingCoroutine == null)
                _shootingCoroutine = StartCoroutine(Shooting());
        }

        public void ClearAllAreas()
        {
            foreach (var area in _shootAreas)
            {
                area.ClearArea();
            }
            _shootAreas.Clear();
        }

        private IEnumerator Shooting()
        {
            while (_shootAreas.Count > 0)
            {
                // Alternately shoot from each area
                for (var i = 0; i < _shootAreas.Count; i++)
                {
                    var area = _shootAreas[i];
                    yield return new WaitForSeconds(_delayBetweenShot);
                    area.SpawnArrow(arrowPrefab);
                }
            }
        
            _shootingCoroutine = null;
        }

        private void Start()
        {
            _archerPosition = transform.position;
        }
    }
}