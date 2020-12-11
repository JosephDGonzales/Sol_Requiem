using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunAmmo : MonoBehaviour
{
    public int maxAmmo = 4;
    public int maxReserveAmmo = 12;
    public int LaserGunReserveAmmo;

    public void AddLaserGunAmmo()
    {
        maxReserveAmmo += maxAmmo;
        Debug.Log("Ammo Added!");

        if (maxReserveAmmo >= 12)
        {
            maxReserveAmmo = 12;
        }
    }

    public void DecreaseLaserGunAmmo()
    {
        maxReserveAmmo -= FindObjectOfType<LaserGunShooting>().ReloadAmmo;

        if (maxReserveAmmo <= 0)
        {
            maxReserveAmmo = 0;
        }

    }
}
