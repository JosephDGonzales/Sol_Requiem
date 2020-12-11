using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunAmmoBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && FindObjectOfType<MachineGunAmmo>().maxReserveAmmo < 150)
        {
            Destroy(gameObject);
            MachineGunAmmo Replenish = collision.GetComponentInChildren<MachineGunAmmo>();
            Replenish.AddMachineGunAmmo();
            Debug.Log("Gained Machine Gun ammo!");
        }

    }
}
