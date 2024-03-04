using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    float xInput;
    float playerSpeed;

    GameObject scythe, cursor;
    public scytheScript scytheSc;
    public bool isDashing;

    Vector3 mousePos;
    // Start is called before the first frame update

    //I CANT SPELL
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSpeed = 10;
        isDashing = false;
        scythe = GameObject.Find("ScytheParent");
        cursor = GameObject.Find("cursor");
        scytheSc=GameObject.Find("ScytheParent").GetComponent<scytheScript>();

    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        cursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);

        if (Input.GetMouseButtonDown(0) && !isDashing) // when throwing the scythe
        {
            scytheSc.activate = true;
            isDashing = true;
        }
        else if (Input.GetMouseButtonDown(0) && isDashing) // after dashing
        {
            transform.position = scythe.transform.position;
            scytheSc.followPlayer=true;
            scytheSc.aim = true;

            isDashing = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(xInput * playerSpeed, rb.velocity.y); // lateral movement
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spike") SceneManager.LoadScene("scene_2");
        if (collision.gameObject.tag == "death") SceneManager.LoadScene("scene_1");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "flag") SceneManager.LoadScene("scene_2");
        if (collision.gameObject.tag == "flag2") SceneManager.LoadScene("scene_3");
    }
}
