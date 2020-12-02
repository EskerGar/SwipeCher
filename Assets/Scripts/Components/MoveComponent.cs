using Settings;
using UnityEngine;

namespace Components
{
    public class MoveComponent : MonoBehaviour
    {

        [SerializeField] private LevelSettings levelSettings;
        [SerializeField] private bool forwardDirect;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            var direction = transform.up;
            // Check steering axe
            if (forwardDirect)
                direction = transform.forward;
            
            transform.position += direction * (levelSettings.ArcherSpeed * Time.deltaTime);
        }
    }
}
