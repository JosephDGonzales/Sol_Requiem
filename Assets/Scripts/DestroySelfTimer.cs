using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfTimer : MonoBehaviour
{
    public float destTimer;

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
        Destroy(gameObject);
    }
}
