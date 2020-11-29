using Arrow;
using Settings;
using UnityEngine;

namespace Archer
{
        public class ArcherBehaviour : MonoBehaviour
        {
                [SerializeField] private ArcherSettings archerSettings;

                public static Transform ArcherTransform { get; private set; }

                private ArcherHealth _playerHealth;
                private ShootAreaController _shootAreaController;

                private void Awake()
                { 
                        ArcherTransform = transform;
                        _playerHealth = GetComponent<ArcherHealth>();
                        _shootAreaController = GetComponent<ShootAreaController>();
                        _playerHealth.Initialize(archerSettings.HealthPoints, archerSettings.RestoreHealthPointsPerSec);
                        _shootAreaController.Initialize(archerSettings.DelayBetweenShot);
                }
        }
}