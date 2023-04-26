using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    private HealthSytem healthSytem;

    private void Awake()
    {
        healthSytem = new HealthSytem(maxHealth);
        
    }


    public HealthSytem GetHealthSytem()
    {
        return healthSytem;
    }


    private void Update()
    {
        currentHealth = healthSytem.GetHealth();
    }

}
