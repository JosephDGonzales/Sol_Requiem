using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmoBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            PistolAmmo Replenish = collision.GetComponentInChildren<PistolAmmo>();
            Replenish.AddPistolAmmo();
            Debug.Log("Gained 15 pistol ammo!");
        }
    }
}