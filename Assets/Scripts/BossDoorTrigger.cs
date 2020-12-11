using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorTrigger : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            door.SetActive(true);
            FindObjectOfType<AudioManagerGame>().Pause("Background");
            gameObject.SetActive(false);
        }    
    }
}
