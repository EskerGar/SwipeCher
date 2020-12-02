using System;
using System.Collections;
using UnityEngine;

namespace Components
{
    public class HealthComponent : MonoBehaviour
    {
        public event Action<float> OnChangeHealth;
        public event Action OnDead;
    
        protected float HealthPoints = 1;
        protected float MaxHealthPoints = 1;
    
        private Animator _animator;

        public void TakeDamage(float damage)
        {
            ChangeHealth(-damage);
        }

        protected void ChangeHealth(float amount)
        {
            HealthPoints += amount;
            // Rounding to min and max
            HealthPoints = Mathf.Clamp(HealthPoints, 0, MaxHealthPoints);
            OnChangeHealth?.Invoke(HealthPoints);
            if (HealthPoints != 0) return;
            OnDead?.Invoke();
            // Check for availability death animation
            if (_animator != null)
                StartCoroutine(AnimationDeath());
        }
    
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    
        private IEnumerator AnimationDeath()
        {
            _animator.Play("Death1");
            yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);
            Destroy(gameObject);
        }

        // Clear all subscribed methods
        private void OnDestroy()
        {
        
            OnChangeHealth = null;
            OnDead = null;
        }
    }
}
