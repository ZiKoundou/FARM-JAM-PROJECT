using UnityEngine;
using System;
using System.ComponentModel;
public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    #region Events
    public event Action OnDamaged;
    public event Action OnHealed;
    public event Action OnDeath;
    #endregion
    private void Awake()
    {
        currentHealth = maxHealth;
    }
    #region Methods
    
    public void TakeDamage(float amount)
    {
        if(amount <= 0) return;
        currentHealth = Mathf.Max(currentHealth - amount, 0f);
        OnDamaged?.Invoke();

        if (currentHealth <= 0f){
            Die();
        }
    }

    public void Heal(float amount)
    {
        if(amount <= 0) return;
        currentHealth = Mathf.Min(currentHealth += amount, maxHealth);
        OnHealed?.Invoke();
        
    }
    public void Die()
    {
        Debug.Log("invoking the death event");
        OnDeath?.Invoke();
    }
    #endregion

}