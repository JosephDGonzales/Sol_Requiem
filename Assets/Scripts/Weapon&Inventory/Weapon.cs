using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public WeaponType weaponType;

    public enum WeaponType
    {
        Pistol,
        Shotgun,
        MachineGun,
        LaserGun,
        Chainsaw
    }

    public WeaponType GetWeaponType()
    {
        return weaponType;
    }
}