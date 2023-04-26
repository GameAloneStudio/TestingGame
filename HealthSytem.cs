using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSytem 
{
    private int currentHealth;
    private int maxHealth;
    public event EventHandler OnHealthChange;

    public HealthSytem(int maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
       currentHealth -= damageAmount;
        
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        OnHealthChange?.Invoke(this, EventArgs.Empty);
    }

    public void Heal(int healAmount)
    {

        currentHealth += healAmount;

        if(currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        OnHealthChange?.Invoke(this, EventArgs.Empty);
    }

    public float GetHealthPercantage()
    {
       return (float)currentHealth / maxHealth;
    }

    public int GetHealth()=> currentHealth;
}
