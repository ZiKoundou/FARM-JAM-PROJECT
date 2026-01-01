 using UnityEngine;
using System;
public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float health = 1;
    [SerializeField] GameObject deathParticles;
    public static event Action OnEnemyDied;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Die()
    {
        // do death stuff...
        OnEnemyDied?.Invoke();
        Destroy(gameObject);
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            if(deathParticles != null)
            {
                Instantiate(deathParticles, gameObject.transform.position, Quaternion.identity);
            }
            
            Die();
        }
    }
}
