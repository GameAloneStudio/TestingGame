 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth PlayerHealth;
    private Transform bar;
    
    void Start()
    {
        bar = transform.Find("Bar");
        PlayerHealth.GetHealthSytem().OnHealthChange += HealthBarUI_OnHealthChange;
    }

    private void HealthBarUI_OnHealthChange(object sender, System.EventArgs e)
    {
        bar.GetComponent<Image>().fillAmount = PlayerHealth.GetHealthSytem().GetHealthPercantage();
    }
}
