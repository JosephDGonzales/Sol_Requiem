using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyType1;
    public int numberOfEnemy1;
    public Transform spawnPoint1;

    public GameObject EnemyType2;
    public int numberOfEnemy2;
    public Transform spawnPoint2;

    public GameObject EnemyType3;
    public int numberOfEnemy3;
    public Transform spawnPoint3;

    // Start is called before the first frame update
    void Start()
    {
        //numberOfEnemy1 = 1;
        //numberOfEnemy2 = 1;
        //numberOfEnemy3 = 1;
    }

    void Spawn()
    {
        for (int i = 0; i < numberOfEnemy1; i++)
            Instantiate(EnemyType1, spawnPoint1.position, spawnPoint1.rotation);

        for (int j = 0; j < numberOfEnemy2; j++)
            Instantiate(EnemyType2, spawnPoint2.position, spawnPoint2.rotation);

        for (int k = 0; k < numberOfEnemy3; k++)
            Instantiate(EnemyType3, spawnPoint3.position, spawnPoint3.rotation);

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
