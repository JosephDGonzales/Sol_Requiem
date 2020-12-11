using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmoBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && FindObjectOfType<ShotgunAmmo>().maxReserveAmmo < 21)
        {
            Destroy(gameObject);
            ShotgunAmmo Replenish = collision.GetComponentInChildren<ShotgunAmmo>();
            Replenish.AddShotgunAmmo();
            Debug.Log("Gained shotgun ammo!");
        }
    }
}
