using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    float xInput;
    public float jumpForce;
    [SerializeField] float playerSpeed;
    private GameObject feet;
    [SerializeField] bool isGrounded;
    public LayerMask platformMask;
    public GameObject teleportPlayer;
    public Color playerColour;
    float dashSpeed;
    GameObject cursor;

    public gameManager gmScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //feet = GameObject.Find("feet");
        cursor = GameObject.Find("mouseCursor");

        playerColour = GetComponent<SpriteRenderer>().color;
        dashSpeed = 10;
        playerSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        GetComponent<SpriteRenderer>().color = playerColour;
    }
    void FixedUpdate()
    {
        if (!gmScript.isDashing) rb.velocity = new Vector2(xInput * playerSpeed, rb.velocity.y); // lateral movement
        //else { transform.position = Vector2.MoveTowards(transform.position, teleportPlayer.transform.position, dashSpeed); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spike") SceneManager.LoadScene("scene_2");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "flag") SceneManager.LoadScene("scene_2");
        if (collision.gameObject.tag == "flag2") SceneManager.LoadScene("scene_3");
    }
}
