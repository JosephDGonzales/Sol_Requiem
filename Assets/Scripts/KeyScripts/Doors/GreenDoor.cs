using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDoor : MonoBehaviour
{
    public Key green;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && green.greenHeld)
        {
            Destroy(gameObject);
            green.greenHeld = false;
        }
    }
}
