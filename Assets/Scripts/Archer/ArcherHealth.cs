using System.Collections;
using Components;
using UnityEngine;

namespace Archer
{
    public class ArcherHealth : HealthComponent
    {
        private float _restoreHealthPointsPerSec;
        public float GetMaxHealthPoints => MaxHealthPoints;

        public void Initialize(float healthPoints, float restoreHealthPointsPerSec)
        {
            HealthPoints = healthPoints;
            MaxHealthPoints = healthPoints;
            _restoreHealthPointsPerSec = restoreHealthPointsPerSec;
            StartCoroutine(Regeneration());
        }

        private void AddHealthPoints()
        {
            ChangeHealth(_restoreHealthPointsPerSec);
        }

        private IEnumerator Regeneration()
        {
            while (gameObject != null)
            {
                yield return new WaitForSeconds(1f);
                AddHealthPoints();
            }
        }
    
    }
}
