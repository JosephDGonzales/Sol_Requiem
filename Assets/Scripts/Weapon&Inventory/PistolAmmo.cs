using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmo : MonoBehaviour
{
    public int maxAmmo = 15;
    public int maxReserveAmmo = 99;
    public int PistolReserveAmmo;

    public void AddPistolAmmo()
    {
        maxReserveAmmo += maxAmmo;
        Debug.Log("Ammo Added!");

        if (maxReserveAmmo >= 99)
        {
            maxReserveAmmo = 99;
        }    
    }

    public void DecreasePistolAmmo()
    {
        //maxReserveAmmo -= FindObjectOfType<PistolShooting>().ReloadAmmo;

        if (maxReserveAmmo <= 0)
        {
            maxReserveAmmo = 0;
        }    

    }    
}