using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpawnChaser : MonoBehaviour
{
    public GameObject Chaser;
    public GameObject Gunner;
    public Transform spawnPoint;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnGunnerPoint;
    public Transform spawnGunnerPoint1;
    public float SpawnRate;
    public float NextSpawn;

    public FieldOfView fov;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRate = 2.0f;
        NextSpawn = Time.time;
    }

    void CheckIfTimeToSpawn()
    {
        if (Time.time > NextSpawn)
        {
            Instantiate(Chaser, spawnPoint.position, spawnPoint.rotation);
            Instantiate(Chaser, spawnPoint1.position, spawnPoint1.rotation);
            Instantiate(Chaser, spawnPoint2.position, spawnPoint2.rotation);
            Instantiate(Chaser, spawnPoint3.position, spawnPoint3.rotation);
            Instantiate(Gunner, spawnGunnerPoint.position, spawnGunnerPoint.rotation);
            Instantiate(Gunner, spawnGunnerPoint1.position, spawnGunnerPoint1.rotation);
            NextSpawn = Time.time + SpawnRate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fov.visibleTargets.Count > 0)
        {
            CheckIfTimeToSpawn();
        }     
    }

    /*
    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            CheckIfTimeToSpawn();
        }
    }
    */
}