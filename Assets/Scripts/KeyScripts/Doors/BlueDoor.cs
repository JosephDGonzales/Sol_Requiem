using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : MonoBehaviour
{
    public Key blue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && blue.blueHeld)
        {
            Destroy(gameObject);
            blue.blueHeld = false;
        }    
    }
}
