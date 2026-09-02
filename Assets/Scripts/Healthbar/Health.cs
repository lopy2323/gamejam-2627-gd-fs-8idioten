using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    public event Action HealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void SetHealth(int newHealth)
    {
        currentHealth = newHealth;
        HealthChanged?.Invoke();
    }

}
