using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDoor : MonoBehaviour
{
    public Key yellow;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && yellow.yellowHeld)
        {
            Destroy(gameObject);
            yellow.yellowHeld = false;
        }
    }
}
