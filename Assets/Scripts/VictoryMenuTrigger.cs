using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMenuTrigger : MonoBehaviour
{
    public GameObject victoryScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManagerGame>().Pause("Background");
            FindObjectOfType<Victory>().VictoryMenu(); 
        }
    }
}
