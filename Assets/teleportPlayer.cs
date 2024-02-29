using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class teleportPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    float xInput;
    float teleportSpeed;
    GameObject player;
    GameObject cursor;

    gameManager gameManagerScript;

    public Color playerColour;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject.Find("player");
        cursor = GameObject.Find("mouseCursor");
        teleportSpeed = 10; // scythe speed
        playerColour = GetComponent<SpriteRenderer>().color;
        gameManagerScript = GameObject.Find("GameManager").GetComponent<gameManager>();
        transform.up = cursor.transform.position - transform.position; // the scythe will follow the mouse.
        rb.velocity = transform.up * teleportSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManagerScript.teleportMode == true)
        {
            //rb.velocity = transform.up * teleportSpeed; // throwable scythe
            rb.AddForce(rb.velocity);
        }
        

     //   Destroy(gameObject, 2.7f);
        GetComponent<SpriteRenderer>().color = playerColour;
    }
}
