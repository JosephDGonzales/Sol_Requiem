using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInventory : MonoBehaviour
{

    private InventoryPlayer inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // spawn the sun button at the first available inventory slot ! 


            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == false)
                {   // check whether the slot is EMPTY
                    inventory.items[i] = true; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }

    }
}