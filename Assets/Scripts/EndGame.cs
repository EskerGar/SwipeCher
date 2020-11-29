using Archer;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private ArcherHealth archerHealth;

    private void Start()
    {
        Time.timeScale = 1;
        archerHealth.OnDead += () => Time.timeScale = 0;
        archerHealth.OnDead += DeathCounter.SaveChanges;
    }

    private void OnDestroy()
    {
        archerHealth.OnDead -= DeathCounter.SaveChanges;
    }
}