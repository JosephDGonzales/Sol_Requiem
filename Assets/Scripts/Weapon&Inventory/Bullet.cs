using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    //public float BulletIntelligence;
    //private Transform target;

    /*
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    */

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }

    /*
    void Update()
    {
            transform.position = Vector2.MoveTowards(transform.position, target.position, BulletIntelligence * Time.deltaTime);
    }
    */
}
