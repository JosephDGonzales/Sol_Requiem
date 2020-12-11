using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public event EventHandler OnWeaponsChanged;

    private List<Weapon.WeaponType> weaponList;

    private void Awake()
    {
        weaponList = new List<Weapon.WeaponType>();
    }

    public List<Weapon.WeaponType> GetKeyList()
    {
        return weaponList;
    }

    public void AddWeapon(Weapon.WeaponType weaponType)
    {
        Debug.Log("Added Weapon: " + weaponType);
        weaponList.Add(weaponType);
        OnWeaponsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveWeapon(Weapon.WeaponType weaponType)
    {
        Debug.Log("Removed Weapon: " + weaponType);
        weaponList.Remove(weaponType);
        OnWeaponsChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsWeapon(Weapon.WeaponType weaponType)
    {
        return weaponList.Contains(weaponType);
    }
}