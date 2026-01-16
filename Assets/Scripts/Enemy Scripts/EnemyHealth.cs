using UnityEngine;
using UnityEngine.Events;
using System;
public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [HideInInspector] public Health health;
    [SerializeField] GameObject deathParticles;
    public static event Action OnEnemyDeath;
    public UnityEvent OnEnemyDamagedUnity;
    public UnityEvent OnEnemyDeathUnity;

    private void OnEnable()
    {
        health = GetComponent<Health>();
        health.OnDamaged += HandleDamaged;
        health.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        health.OnDamaged -= HandleDamaged;
        health.OnDeath -= HandleDeath;
    }
    public void HandleDamaged()
    {
        OnEnemyDamagedUnity?.Invoke();
    }
    public void HandleDeath()
    {
        Debug.Log("enemy death event");
        OnEnemyDeath?.Invoke();
        OnEnemyDeathUnity?.Invoke();
        Destroy(gameObject);
    }

}
