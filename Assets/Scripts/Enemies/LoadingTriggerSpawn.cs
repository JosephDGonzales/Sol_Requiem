using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingTriggerSpawn : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    public GameObject Enemy6;
    public GameObject Enemy7;
    public GameObject Enemy8;
    public GameObject Enemy9;
    public GameObject Enemy10;
    public GameObject Enemy11;
    public GameObject Enemy12;
    public GameObject Enemy13;
    public GameObject Enemy14;
    public GameObject Enemy15;
    public GameObject Enemy16;
    public GameObject Enemy17;
    public GameObject Enemy18;
    public GameObject Enemy19;
    public GameObject Enemy20;
    public GameObject Enemy21;

    void Spawn()
    {
        Enemy1.SetActive(true);
        Enemy2.SetActive(true);
        Enemy3.SetActive(true);
        Enemy4.SetActive(true);
        Enemy5.SetActive(true);
        Enemy6.SetActive(true);
        Enemy7.SetActive(true);
        Enemy8.SetActive(true);
        Enemy9.SetActive(true);
        Enemy10.SetActive(true);
        Enemy11.SetActive(true);
        Enemy12.SetActive(true);
        Enemy13.SetActive(true);
        Enemy14.SetActive(true);
        Enemy15.SetActive(true);
        Enemy16.SetActive(true);
        Enemy17.SetActive(true);
        Enemy18.SetActive(true);
        Enemy19.SetActive(true);
        Enemy20.SetActive(true);
        Enemy21.SetActive(true);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            Spawn();
        }
    }
}
