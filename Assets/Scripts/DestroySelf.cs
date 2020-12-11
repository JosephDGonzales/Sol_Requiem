using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float destTimer;

    void Start()
    {
        //destTimer = 1.0f;
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(destTimer);
        Die();
    }

    public void animEndDestroy()
    {
        StartCoroutine("DeathTimer");
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
