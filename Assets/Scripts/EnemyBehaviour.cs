using System.Collections;
using Archer;
using Components;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float damage;

    private const float RotationSpeed = 6f;
    private const float MeleeRange = 2.5f;
    
    private bool _isNearArcher;
    private NavMeshAgent _navMeshAgent;
    private float _attackDelay;
    private Vector3 _archerPosition;
    private HealthComponent _healthComponent;
    private Animator _animator;

    public void Initialize(float attackDelay, float speed)
    {
        _attackDelay = attackDelay;
        _navMeshAgent.speed = speed;
        _healthComponent = GetComponent<HealthComponent>();
        _healthComponent.OnDead += DeathCounter.AddDeath;
        _healthComponent.OnDead += WhenDead;
    }

    private void WhenDead()
    {
        _animator.StopPlayback();
        StopAllCoroutines();
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnDestroy()
    {
        _healthComponent.OnDead -= WhenDead;
        _healthComponent.OnDead -= DeathCounter.AddDeath;
    }


    private void Update ()
    {
        // Turn the enemy towards the archer
        if (!IsInMeleeRangeOf(_archerPosition)) return;
        _navMeshAgent.speed = 0f;
        RotateTowards(_archerPosition);
        _navMeshAgent.SetDestination(_archerPosition);
    }
    
    private void Start()
    {
        // NavMesh settings
        _navMeshAgent.enabled = true;
        _navMeshAgent.Warp(transform.position);
        _archerPosition = ArcherBehaviour.ArcherTransform.position;
        _navMeshAgent.SetDestination(_archerPosition);
        _navMeshAgent.updateRotation = true;
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var archerHealth = other.gameObject.GetComponent<ArcherHealth>();
        // Check on archer's exist
        if (archerHealth == null) return;
        _isNearArcher = true;
        StartCoroutine(DealingDamage(archerHealth));
    }

    
    private bool IsInMeleeRangeOf (Vector3 position) 
    {
        var distance = Vector3.Distance(transform.position, position);
        return distance < MeleeRange;
    }
    
    private void OnTriggerExit(Collider other)
    {
        var archerHealth = other.gameObject.GetComponent<ArcherHealth>();
        if (archerHealth != null)
            _isNearArcher = false;
    }

    private void RotateTowards(Vector3 position)
    {
        var direction = (position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);
    }

    // Damage archer per _attackDelay when near 
    private IEnumerator DealingDamage(HealthComponent archerHealth)
    {
        while (_isNearArcher && archerHealth != null)
        {
            _animator.Play("Attack1");
            archerHealth.TakeDamage(damage);
            yield return new WaitForSeconds(_attackDelay);
        }
    }
}