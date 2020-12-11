using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedMultiplier = 10.0f;    // Play around with this setting to optimize the right speed for the player in the inspector.
    public Rigidbody2D rb;

    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    public Sprite playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        FindObjectOfType<AudioManagerGame>().Play("Background");
        spriteRenderer.sprite = playerSprite;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); 
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speedMultiplier * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Hidden")
        {
            Debug.Log("You are hidden.");
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = playerSprite;
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }

        if (collide.gameObject.tag == "web")
        {
            speedMultiplier = speedMultiplier / 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Hidden")
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = playerSprite;
            spriteRenderer.color = new Color(1, 1, 1, 1f);
        }

        if (collide.gameObject.tag == "web")
        {
            speedMultiplier = speedMultiplier * 2;
        }
    }
}