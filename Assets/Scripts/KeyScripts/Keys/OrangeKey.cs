using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeKey : MonoBehaviour
{
    public Key orange;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            orange.orangeHeld = true;
        }
    }


}