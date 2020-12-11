using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDeath : MonoBehaviour
{
    public GameObject window;

    public GameObject objectOnDeath;

    public EnemyHealth objectHealth;

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(objectOnDeath, transform.position, Quaternion.identity);
        //Destroy(effect, 2f);
        //Destroy(gameObject);
    }
    */

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (objectHealth.currentHealth <= 0)
        {
            GameObject spawnObject = Instantiate(objectOnDeath, transform.position, Quaternion.identity);
            //GameObject spawnObject = Instantiate(objectOnDeath, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
