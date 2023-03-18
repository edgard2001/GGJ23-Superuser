using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public static event Action OnPlayerDeath;
    public int minHealth;
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = minHealth;
        healthBar.SetMaxHealth(minHealth);
    }

    void Update()
    {
        
    }

    void TakeDamage(int damage)
    {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth >= 100)
        {
            currentHealth = 100;
            Debug.Log("dead");
            OnPlayerDeath?.Invoke();
        }
    }
}
