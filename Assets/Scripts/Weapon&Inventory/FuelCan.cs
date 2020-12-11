using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCan : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                ChainSawAmmo Replenish = collision.GetComponentInChildren<ChainSawAmmo>();
                Replenish.AddChainsawAmmo();
                Debug.Log("Gained Chainsaw ammo!");
            }
        
    }
}