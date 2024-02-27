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
        teleportSpeed = 40;
        playerColour = GetComponent<SpriteRenderer>().color;
        gameManagerScript = GameObject.Find("GameManager").GetComponent<gameManager>();

        transform.up = cursor.transform.position - transform.position; // the scythe will follow the mouse.
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * teleportSpeed; // throwable scythe

     //   Destroy(gameObject, 2.7f);
        GetComponent<SpriteRenderer>().color = playerColour;
    }
}
