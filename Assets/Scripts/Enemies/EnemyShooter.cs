using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    private Transform target;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public FieldOfView fov;

    public float bulletForce = 20f;

    private float timeBetShots;
    public float startTimeBetShots;

    //private Animator shootAnim;

    //public string shootAnimName;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBetShots = startTimeBetShots;

        //shootAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //shootAnim.SetBool("isAttacking", false);

        if (fov.visibleTargets.Count > 0)
        {
            if (timeBetShots <= 0)
            {
                //shootAnim.SetBool("isAttacking", true);
                Shoot();
                timeBetShots = startTimeBetShots;
            }
            else
            {
                timeBetShots -= Time.deltaTime;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
