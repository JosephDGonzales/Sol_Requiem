using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeDoor : MonoBehaviour
{
    public Key orange;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && orange.orangeHeld)
        {
            Destroy(gameObject);
            orange.orangeHeld = false;
        }
    }
}
