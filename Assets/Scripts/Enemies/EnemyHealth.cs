using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public GameObject Enemy;

    public int maxHealth = 100;
    public int currentHealth;

    private float explodeCool;
    private float nextExplode;
    private float spaceCool;
    private float nextSpace;

    // Start is called before the first frame update
    void Start()
    {
        explodeCool = 1.0f;
        nextExplode = Time.time;

        spaceCool = 1.0f;
        nextSpace = Time.time;

        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(25);
        }

        if (collision.gameObject.tag == "SG Bullet")
        {
            TakeDamage(50);
            //Debug.Log("You have been shot.");
        }

        if (collision.gameObject.tag == "MG Bullet")
        {
            TakeDamage(20);
            //Debug.Log("You have been shot.");
        }

        if (collision.gameObject.tag == "Laser Bullet")
        {
            TakeDamage(100);

            if (gameObject.name == "Spider Boss")
                TakeDamage(900);

            //Debug.Log("You have been shot.");
        }

        if (Time.time > nextExplode)
        {
            if (collision.gameObject.tag == "explosion")
            {
                TakeDamage(50);
                nextExplode = Time.time + explodeCool;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        /*
        if (Time.time > nextAcid)
        {
            if (collide.gameObject.tag == "AcidPool")
            {
                TakeDamage(5);
                nextAcid = Time.time + acidCool;
            }
        }
        */

        if (Time.time > nextSpace)
        {
            if (collide.gameObject.tag == "Space")
            {
                TakeDamage(40);
                nextSpace = Time.time + spaceCool;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.name != "Explode Enemy" && gameObject.tag != "window")
                Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}