using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfind : MonoBehaviour
{
    private Rigidbody2D rb;
    public float PatrolSpeed = 8f;
    public Transform[] moveSpots;   //Placements where the enemy can move to.
    private int randomSpot;         //Picks the random spot to patrol towards.
    private float waitTime;
    public float startWaitTime;

    private int changeDir = 0;

    public float rotationSpeed = 20f;

    public FieldOfView fov;

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

    private Animator anim;

    public string walkAnimName;

    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //EnemyTarget = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        randomSpot = Random.Range(0, moveSpots.Length); //Sets int variable equal to a random number of spot to patrol to.
        waitTime = startWaitTime;
        //rotationTimer = startRotationTimer;

        anim = GetComponent<Animator>();
        anim.enabled = false;
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

        if (fov.visibleTargets.Count == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, PatrolSpeed * Time.deltaTime); //Moves to the random location.
            anim.enabled = true;

            if (changeDir == 0)
            {
                Vector3 direction = moveSpots[randomSpot].position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                direction.Normalize();
                changeDir = 1;
            }
                

            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length); 
                    changeDir = 0;
                    waitTime = startWaitTime;
                }
                else if (waitTime <= startWaitTime / 2f)
                {
                    transform.Rotate(Vector3.forward * -rotationSpeed * 2f * Time.deltaTime);

                    waitTime -= Time.deltaTime;
                }
                else
                {
                    transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

                    waitTime -= Time.deltaTime;
                }
            }

            /*
            if (fov.visibleTargets.Count > 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, PatrolSpeed * Time.deltaTime);
                Vector3 direction = target.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                direction.Normalize();
            }

            if (fov.visibleTargets.Count < 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, PatrolSpeed * Time.deltaTime);
                Vector3 direction = moveSpots[randomSpot].position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                direction.Normalize();
            }
            */
        }
    }
}
