using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class SentryScript : MonoBehaviour
{
    public float rotationSpeed;
    //public float distance;
    private Rigidbody2D rb;

    private Transform Player;

    //public LineRenderer SentrySight;
    public Gradient redColor;
    public Gradient greenColor;

    private float timeBetShots;
    public float startTimeBetShots;

    public float bulletForce = 20f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public FieldOfView fov;

    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.queriesStartInColliders = false;

        //Player = GameObject.FindGameObjectWithTag("Player").transform;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBetShots = startTimeBetShots;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (fov.visibleTargets.Count > 0)
        {
            //Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            //SentrySight.SetPosition(1, hitInfo.point);
            //SentrySight.colorGradient = redColor;
            Vector3 direction = Player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

            if (timeBetShots <= 2)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                timeBetShots = startTimeBetShots;
            } else
            {
                timeBetShots -= Time.deltaTime;
            }
        } else
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            //Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            //SentrySight.SetPosition(1, transform.position + transform.right * distance);
            //SentrySight.colorGradient = greenColor;
        }

        //SentrySight.SetPosition(0, transform.position);
    }
}