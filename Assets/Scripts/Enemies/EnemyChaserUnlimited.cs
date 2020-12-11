using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaserUnlimited : MonoBehaviour
{
    private Rigidbody2D rb;
    private float EnemySpeed = 8f;

    public FieldOfView fov;
    /*
    public GameObject DoorA;
    public GameObject DoorB;
    public GameObject DoorC;
    public GameObject DoorD;
    public GameObject DoorE;
    public GameObject DoorF;*/

    public GameObject Enemy;

    private Transform target;
    private Transform EnemyTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        EnemyTarget = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Physics2D.IgnoreCollision(Enemy.GetComponent<Collider2D>(), DoorA.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(Enemy.GetComponent<Collider2D>(), DoorB.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(Enemy.GetComponent<Collider2D>(), DoorC.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(Enemy.GetComponent<Collider2D>(), DoorD.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(Enemy.GetComponent<Collider2D>(), DoorE.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(Enemy.GetComponent<Collider2D>(), DoorF.GetComponent<Collider2D>(), true);
        */

        if (fov.visibleTargets.Count > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, EnemySpeed * Time.deltaTime);
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            direction.Normalize();
        }

        if (Vector2.Distance(transform.position, EnemyTarget.position) > 2 && Vector2.Distance(transform.position, EnemyTarget.position) < 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, EnemyTarget.position, -EnemySpeed * Time.deltaTime);
        }

    }
}
