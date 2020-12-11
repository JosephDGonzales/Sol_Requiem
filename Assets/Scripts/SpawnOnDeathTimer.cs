using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDeathTimer : MonoBehaviour
{
    public float destTimer;

    public GameObject objectOnDeath;

    void Start()
    {
        StartCoroutine("DeathTimer");
        //destTimer = 1.0f;
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(destTimer);
        Die();
    }

    void Die()
    {
        GameObject spawnObject = Instantiate(objectOnDeath, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
