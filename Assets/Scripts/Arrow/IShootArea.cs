using UnityEngine;

namespace Arrow
{
        public interface IShootArea
        {
                void SpawnArrow(GameObject arrowPrefab);
                void ClearArea();
        }
}