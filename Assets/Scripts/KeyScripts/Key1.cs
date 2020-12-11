using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Door;
    public GameObject Door1;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), Door.GetComponent<Collider2D>(), false);
        Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), Door1.GetComponent<Collider2D>(), false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            Debug.Log("The Door has been open.");
            Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), Door.GetComponent<Collider2D>(), true);
            Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), Door1.GetComponent<Collider2D>(), true);
            Destroy(gameObject);
        }
    }
}
