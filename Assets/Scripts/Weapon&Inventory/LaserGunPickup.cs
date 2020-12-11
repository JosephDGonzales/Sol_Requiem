using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            WeaponSwap2 Replenish = collision.GetComponentInChildren<WeaponSwap2>();
            Replenish.holdingLaserGun = true;
            Debug.Log("Laser Gun has been picked up!");
        }
    }
}
