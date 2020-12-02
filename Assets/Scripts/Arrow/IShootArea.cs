using UnityEngine;

namespace Arrow
{
        // Interface for the implementation of different areas of shooting
        public interface IShootArea
        {
                void SpawnArrow(GameObject arrowPrefab);
                void ClearArea();
        }
}