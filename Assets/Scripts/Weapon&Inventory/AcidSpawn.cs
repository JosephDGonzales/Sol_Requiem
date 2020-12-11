using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpawn : MonoBehaviour
{
    //public GameObject hitEffect;
    public GameObject acidPool;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(acidPool, transform.position, Quaternion.identity);
        //Destroy(effect, 2f);
        //Destroy(gameObject);
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
