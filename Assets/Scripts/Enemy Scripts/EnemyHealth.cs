using UnityEngine;
using UnityEngine.Events;
using System;
using TMPro;
public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [HideInInspector] public Health health;
    [SerializeField] GameObject deathParticles;
    Animator animator;
    public static event Action OnEnemyDeath;
    public UnityEvent OnEnemyDamagedUnity;
    public UnityEvent OnEnemyDeathUnity;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void OnEnable()
    {
        health = GetComponentInChildren<Health>();
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
        animator.SetTrigger("Hurt");
    }
    public void HandleDeath()
    {
        Debug.Log("enemy death event");
        OnEnemyDeath?.Invoke();
        OnEnemyDeathUnity?.Invoke();
        CurrencyManager.instance.AddMoney(1);
        Destroy(gameObject);
        
    }

}
