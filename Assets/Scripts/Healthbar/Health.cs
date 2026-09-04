using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{
    [SerializeField] private int playerNumber;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    public event Action HealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void Damage(int amount)
    {
        if (amount <= 0)
            return;

        currentHealth = Mathf.Max(currentHealth - amount, 0);
        HealthChanged?.Invoke();

        if (currentHealth == 0)
        {
            gameManager.PlayerDied(playerNumber);
        }
    }
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        HealthChanged?.Invoke();
    }

}


