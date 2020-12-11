using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadTrigger : MonoBehaviour
{
    public GameObject bossEnemy;
    public GameObject bossDoor;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (bossEnemy == null)
            {
                FindObjectOfType<AudioManagerGame>().Play("Background");
                bossDoor.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
