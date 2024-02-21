using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class teleportPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    float xInput;
    float teleportSpeed;
    GameObject player;

    gameManager gameManagerScript;

    public Color playerColour;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject.Find("player");
        teleportSpeed = 10;

        playerColour = GetComponent<SpriteRenderer>().color;

        gameManagerScript = GameObject.Find("GameManager").GetComponent<gameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * teleportSpeed, rb.velocity.y); // lateral movement

        Destroy(gameObject, 2.7f);





        GetComponent<SpriteRenderer>().color = playerColour;
    }
}
