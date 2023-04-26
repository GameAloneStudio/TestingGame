using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] float fireRate =1f;
    [SerializeField] private Transform bulletTransform;
    private float bulletTimer;
    private float bulletTimerMax = 4;
    private void Update()
    {
        bulletTimer += Time.deltaTime + fireRate;
        if (Input.GetMouseButton(0))
        {
            if(bulletTimer > bulletTimerMax)
           {
            bulletTimer = 0;
            Instantiate(bulletTransform);
           }
        }
    }
}
