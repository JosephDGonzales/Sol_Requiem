﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyanKey : MonoBehaviour
{
    public Key cyan;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            cyan.cyanHeld = true;
        }
    }


}
