using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject BossObject;
    public GameObject EnemyType1;
    public Transform spawnPoint;
    public float SpawnRate;
    public float NextSpawn;
    private int MinSpawn;
    private int MaxSpawn;

    public FieldOfView fov;

    // Start is called before the first frame update
    void Start()
    {
        NextSpawn = Time.time;
        MinSpawn = 0;
        MaxSpawn = 5;
        EnemyHealth enemyHealth = BossObject.GetComponent<EnemyHealth>();
    }

    void CheckIfTimeToSpawn()
    {
        if (Time.time > NextSpawn)
        {
            for (int i = 0; i < 4; i++)
                Instantiate(EnemyType1, spawnPoint.position, spawnPoint.rotation);

            NextSpawn = Time.time + SpawnRate;
        }
    }

    void BossHealthSpawn()
    {
        if (MinSpawn < MaxSpawn)
        {
            for (int i = 0; i < 6; i++)
                Instantiate(EnemyType1, spawnPoint.position, spawnPoint.rotation);
            
            MinSpawn++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHealth enemyHealth = BossObject.GetComponent<EnemyHealth>();
        if (fov.visibleTargets.Count > 0)
        {
            CheckIfTimeToSpawn();
        }


        /*
        if (enemyHealth.currentHealth <= 80 && MinSpawn == 0)
        {
            BossHealthSpawn();
        }
        if (enemyHealth.currentHealth <= 40 && MinSpawn == 1)
        {
            BossHealthSpawn();
        }
        */
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