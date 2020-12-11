using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleKey : MonoBehaviour
{
    public Key purple;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            purple.purpleHeld = true;
        }
    }


}