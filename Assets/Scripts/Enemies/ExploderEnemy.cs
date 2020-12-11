using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderEnemy : MonoBehaviour
{
    public float radius;
    public float force;
    public float expSpeed;

    public LayerMask LayerToHit;

    public GameObject explosionVFX;

    private Animator explodeAnim;
    public string explodeAnimName;

    //private Health playerHealth;
    public EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        explodeAnim = GetComponent<Animator>();
        explodeAnim.enabled = false;
    }

    void Update()
    {
        if (enemyHealth.currentHealth <= 0)
        {
            StartCoroutine("BombTimer");
            Debug.Log("Explode Lmao.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            explodeAnim.enabled = true;
            explodeAnim.Play(explodeAnimName);

            StartCoroutine("BombTimer");
            Debug.Log("Explode Lmao.");
        }
    }

    IEnumerator BombTimer()
    {
        yield return new WaitForSeconds(expSpeed);
        Explode();
    }

    void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius, LayerToHit);

        foreach (Collider2D obj in objects) 
        {
            GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);

            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        FindObjectOfType<AudioManagerGame>().Play("Explode");
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
