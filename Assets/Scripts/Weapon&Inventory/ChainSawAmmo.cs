using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSawAmmo : MonoBehaviour
{
    public double maxAmmo = 100;
    public double maxReserveAmmo = 200;
    public double ChainSawReserveAmmo;

    public void AddChainsawAmmo()
    {
        maxReserveAmmo += maxAmmo;
        Debug.Log("Ammo Added!");

        if (maxReserveAmmo >= 200)
        {
            maxReserveAmmo = 200;
        }
    }

    public void DecreaseChainsawAmmo()
    {
        maxReserveAmmo -= FindObjectOfType<ChainSaw>().ReloadAmmo;

        if (maxReserveAmmo <= 0)
        {
            maxReserveAmmo = 0;
        }

    }
}
