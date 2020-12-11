using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            WeaponSwap2 Replenish = collision.GetComponentInChildren<WeaponSwap2>();
            Replenish.holdingShotgun = true;
            Debug.Log("Shotgun has been picked up!");
        }
    }
}
