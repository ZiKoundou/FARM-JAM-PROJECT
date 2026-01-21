using UnityEngine;
using UnityEngine.Events;
using System;
using System.Runtime.InteropServices;

public class MotherHealth : MonoBehaviour
{
    [HideInInspector] public Health health;
    public static event Action OnMotherDeath;
    public UnityEvent OnMotherDamagedUnity;
    public UnityEvent OnMotherDeathUnity;

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
        Debug.Log("Mother plant taking damage");
        OnMotherDamagedUnity?.Invoke();
    }

    public void HandleDeath()
    {
        Debug.Log("you lost dummy");
        OnMotherDeathUnity?.Invoke();
        OnMotherDeath?.Invoke();
        // bring up ui for game over and restart or smthn
    }
}