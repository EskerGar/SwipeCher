using Archer;
using UnityEngine;

namespace UI
{
    public class HealthBarUi : MonoBehaviour
    {
        [SerializeField] private Transform bar;
        [SerializeField] private ArcherHealth archerHealth;

        private void SetSize(float sizeNormalized)
        {
            bar.localScale = new Vector3(sizeNormalized, 1f);
        }

        private void HealthChange(float health)
        {
            var currentHealth = health / archerHealth.GetMaxHealthPoints;
            SetSize(currentHealth);
        }

        private void Start()
        {
            archerHealth.OnChangeHealth += HealthChange;
        }

        private void OnDestroy()
        {
            archerHealth.OnChangeHealth -= HealthChange;
        }
    }
}