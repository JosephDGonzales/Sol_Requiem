using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class PistolAmmoUI : MonoBehaviour
{
    public Text ammoText;
    public PistolShooting pistolAmmo;

    // Update is called once per frame
    void Update()
    {
        ammoText.text = pistolAmmo.currentAmmo.ToString();
    }
}