using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject Player;
    //public GameOver gameOverMenu;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    private float explodeCool;
    private float nextExplode;
    private float acidCool;
    private float nextAcid;
    private float spaceCool;
    private float nextSpace;

    // Start is called before the first frame update

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    void Start()
    {
        explodeCool = 1.0f;
        nextExplode = Time.time;

        acidCool = 0.2f;
        nextAcid = Time.time;

        spaceCool = 0.2f;
        nextSpace = Time.time;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(0);
            //Debug.Log("You have been tagged.");
        }

        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(25);
            //Debug.Log("You have been shot.");
        }

        if (collision.gameObject.tag == "SG Bullet")
        {
            TakeDamage(50);
            //Debug.Log("You have been shot.");
        }

        if (collision.gameObject.tag == "MG Bullet")
        {
            TakeDamage(40);
            //Debug.Log("You have been shot.");
        }

        if (collision.gameObject.tag == "Laser Bullet")
        {
            TakeDamage(75);
            //Debug.Log("You have been shot.");
        }

        if (collision.gameObject.tag == "Acid Bullet")
        {
            TakeDamage(10);
            //Debug.Log("You have been shot.");
        }

        if (collision.gameObject.tag == "Web Bullet")
        {
            TakeDamage(10);
            //Debug.Log("You have been shot.");
        }

        if (Time.time > nextExplode)
        {
            if (collision.gameObject.tag == "explosion")
            {
                TakeDamage(50);
                Debug.Log("You have been exploded.");
                nextExplode = Time.time + explodeCool;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (Time.time > nextAcid)
        {
            if (collide.gameObject.tag == "AcidPool")
            {
                TakeDamage(10);
                nextAcid = Time.time + acidCool;
            }
        }

        if (Time.time > nextSpace)
        {
            if (collide.gameObject.tag == "Space")
            {
                TakeDamage(50);
                nextSpace = Time.time + spaceCool;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            FindObjectOfType<GameOver>().GameOverMenu();
            //Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void GainHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }    
}
