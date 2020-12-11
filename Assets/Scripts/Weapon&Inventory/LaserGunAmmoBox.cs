using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunAmmoBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            LaserGunAmmo Replenish = collision.GetComponentInChildren<LaserGunAmmo>();
            Replenish.AddLaserGunAmmo();
            Debug.Log("Gained Laser Gun ammo!");
        }

    }
}
