using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            WeaponSwap2 Replenish = collision.GetComponentInChildren<WeaponSwap2>();
            Replenish.holdingMachineGun = true;
            Debug.Log("Machine Gun has been picked up!");
        }
    }
}
