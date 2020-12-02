using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Settings/ArcherSettings", fileName = "ArcherSettings")]
    public class ArcherSettings : ScriptableObject
    {
        [Tooltip("Max archers health points")][SerializeField] private float healthPoints;
        [SerializeField] private float restoreHealthPointsPerSec;
        [SerializeField] private float delayBetweenShot;

        public float HealthPoints => healthPoints;

        public float RestoreHealthPointsPerSec => restoreHealthPointsPerSec;

        public float DelayBetweenShot
        {
            get => delayBetweenShot;
            set => delayBetweenShot = value;
        }
    }
}
