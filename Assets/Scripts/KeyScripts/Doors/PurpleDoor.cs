using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleDoor : MonoBehaviour
{
    public Key purple;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && purple.purpleHeld)
        {
            Destroy(gameObject);
            purple.purpleHeld = false;
        }
    }
}
