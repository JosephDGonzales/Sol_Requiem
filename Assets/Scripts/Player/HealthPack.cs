using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && FindObjectOfType<Health>().currentHealth < FindObjectOfType<Health>().maxHealth)
        {
            Destroy(gameObject);
            Health Regen = collision.gameObject.GetComponent<Health>();
            Regen.GainHealth();
            Debug.Log("Gained health!");
        }
    }
}