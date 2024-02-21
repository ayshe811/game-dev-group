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

    public gameManager gmScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feet = GameObject.Find("feet");

        playerColour = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapBox(feet.transform.position, feet.GetComponent<CapsuleCollider2D>().bounds.size, 0, platformMask);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) rb.velocity = Vector2.up * jumpForce; // jump

        // TELEPORT
        if (gmScript.teleportMode)
        {
            playerSpeed = 0;
            playerColour.a = 0.5f;
        }
        else if (!gmScript.teleportMode)
        {
            playerSpeed = 10;
            playerColour.a = 1;
        }
        // TELEPORT



        GetComponent<SpriteRenderer>().color = playerColour;
    }
    void FixedUpdate()
    {
        if (!gmScript.teleportMode) rb.velocity = new Vector2(xInput * playerSpeed, rb.velocity.y); // lateral movement
        else { }
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
