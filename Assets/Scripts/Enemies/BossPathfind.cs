using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPathfind : MonoBehaviour
{
    private Rigidbody2D rb;
    private float EnemySpeed = 8f;

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    //private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    /*
    public GameObject DoorA;
    public GameObject DoorB;
    public GameObject DoorC;
    public GameObject DoorD;
    public GameObject DoorE;
    public GameObject DoorF;
    public GameObject Enemy;
    */

    private Transform target;
    private Transform EnemyTarget;
    public FieldOfView fov;

    private Animator anim;

    public string walkAnimName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        EnemyTarget = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();

        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f)).normalized;
        movementPerSecond = movementDirection * EnemySpeed;
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

        anim.enabled = false;

        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        if (fov.visibleTargets.Count > 0)
        {
            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
            transform.position.y + (movementPerSecond.y * Time.deltaTime));
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            direction.Normalize();

            anim.enabled = true;
            anim.Play(walkAnimName);
        }

        /*
        if (Vector2.Distance(transform.position, target.position) > 5 && Vector2.Distance(transform.position, target.position) < 8)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, EnemySpeed * Time.deltaTime);
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
        }
        */

        if (Vector2.Distance(transform.position, target.position) > 1 && Vector2.Distance(transform.position, target.position) < 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -EnemySpeed * Time.deltaTime);
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            direction.Normalize();

            anim.enabled = true;
            anim.Play(walkAnimName);
        }

        if (Vector2.Distance(transform.position, EnemyTarget.position) > 2 && Vector2.Distance(transform.position, EnemyTarget.position) < 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, EnemyTarget.position, -EnemySpeed * Time.deltaTime);

            anim.enabled = true;
            anim.Play(walkAnimName);
        }
    }
}