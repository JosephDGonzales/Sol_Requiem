using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmo : MonoBehaviour
{
    public int maxAmmo = 7;
    public int maxReserveAmmo = 21;
    public int ShotgunReserveAmmo;

    public void AddShotgunAmmo()
    {
        maxReserveAmmo += maxAmmo;
        Debug.Log("Ammo Added!");

        if (maxReserveAmmo >= 21)
        {
            maxReserveAmmo = 21;
        }
    }

    public void DecreaseShotgunAmmo()
    {
        maxReserveAmmo -= FindObjectOfType<ShotgunShooting>().ReloadAmmo;

        if (maxReserveAmmo <= 0)
        {
            maxReserveAmmo = 0;
        }

    }
}
