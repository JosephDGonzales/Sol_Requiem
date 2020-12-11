using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            WeaponSwap2 Replenish = collision.GetComponentInChildren<WeaponSwap2>();
            Replenish.holdingChainsaw = true;
            Debug.Log("Chainsaw has been picked up!");
        }
    }
}
