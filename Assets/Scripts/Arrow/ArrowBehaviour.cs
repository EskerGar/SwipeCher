using Components;
using UnityEngine;

namespace Arrow
{
    public class ArrowBehaviour : MonoBehaviour
    {
        [SerializeField] private float attackPoints;
    
        public void DestroyArrow() => Destroy(gameObject);

        private void OnTriggerEnter(Collider other)
        {
            var healthComponent = other.gameObject.GetComponent<HealthComponent>();
            if(healthComponent != null)
                healthComponent.TakeDamage(attackPoints);
        }
    
        private void OnBecameInvisible()
        {
            DestroyArrow();
        }
    }
}