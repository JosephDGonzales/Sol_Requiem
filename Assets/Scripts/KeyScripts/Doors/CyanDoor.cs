using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyanDoor : MonoBehaviour
{
    public Key cyan;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && cyan.cyanHeld)
        {
            Destroy(gameObject);
            cyan.cyanHeld = false;
        }
    }
}
