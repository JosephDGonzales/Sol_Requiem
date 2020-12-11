using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public Transform player;
    private Transform target;
    private Rigidbody2D rb;
    public float FireRate;
    public float NextShot;

    // Start is called before the first frame update
    void Start()
    {
        FireRate = 1.0f;
        NextShot = Time.time;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Bang!");
        }
    }

    void CheckIfTimeToFire()
    {
        if (Vector2.Distance(transform.position, target.position) > 0 && Vector2.Distance(transform.position, target.position) < 8)
        {
            if (Time.time > NextShot)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                NextShot = Time.time + FireRate;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (Vector2.Distance(transform.position, target.position) > 30)
        {
            Destroy(gameObject);
        }
    }
}