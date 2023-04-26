using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    [SerializeField] private PlayerHealth playerHealth;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerHealth.GetHealthSytem().TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            playerHealth.GetHealthSytem().Heal(10);
        }
    }
}
