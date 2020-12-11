using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJuggernaut : MonoBehaviour
{
    public float radius;
    public float force;
    public float expSpeed;

    public LayerMask LayerToHit;
    //public CircleCollider2D cc;

    public GameObject explosionVFX;

    //private Health playerHealth;
    //public EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
