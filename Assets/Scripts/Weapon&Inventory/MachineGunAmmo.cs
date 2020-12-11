using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunAmmo : MonoBehaviour
{
    public int maxAmmo = 50;
    public int maxReserveAmmo = 150;
    public int MachineGunReserveAmmo;

    public void AddMachineGunAmmo()
    {
        maxReserveAmmo += maxAmmo;
        Debug.Log("Ammo Added!");

        if (maxReserveAmmo >= 150)
        {
            maxReserveAmmo = 150;
        }
    }

    public void DecreaseMachineGunAmmo()
    {
        maxReserveAmmo -= FindObjectOfType<MachineGunShooting>().ReloadAmmo;

        if (maxReserveAmmo <= 0)
        {
            maxReserveAmmo = 0;
        }

    }
}
