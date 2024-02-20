using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    float xInput;
    public float jumpForce;
    float playerSpeed;
    private GameObject feet;
    [SerializeField] bool isGrounded;
    public LayerMask platformMask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSpeed = 10;

        feet = GameObject.Find("feet");
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapBox(feet.transform.position, feet.GetComponent<CapsuleCollider2D>().bounds.size, 0, platformMask);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) rb.velocity = Vector2.up * jumpForce; // jump
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(xInput * playerSpeed, rb.velocity.y); // lateral movement
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
