using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    public Key red;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && red.redHeld)
        {
            Destroy(gameObject);
            red.redHeld = false;
        }
    }
}

