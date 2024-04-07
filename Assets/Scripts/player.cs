using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
   [SerializeField] float xInput;
    float playerSpeed;
    public float timer;

    public GameObject scythe, cursor;
    public scytheScript scytheSc;

    public bool isDashing, isLerping, moving;
    public scytheScript2 scytheSc2;
    
    public LayerMask groundLayer;
    public bool isGrounded;

    public int scytheCount;

    public Animator anim;
    float animTimer;

    public GameObject Dialogue;

    Vector3 mousePos;
    Vector3 initialPos;

    public bool disabled;
    // Start is called before the first frame update

    //I CANT SPELL
    void Start()
    {
        Application.targetFrameRate = 60;

        rb = GetComponent<Rigidbody2D>();
        playerSpeed = 9;
        isDashing = false;
        scythe = GameObject.Find("ScytheParent");
        cursor = GameObject.Find("cursor");
        scytheSc=GameObject.Find("ScytheParent").GetComponent<scytheScript>();
        scytheSc2=GameObject.Find("ScytheParent2").GetComponent<scytheScript2>();

        scytheCount = 3;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Dialogue.activeSelf == true)
        {
            disabled = true;
        }
        else
        {
            disabled = false;
        }

        scytheSc.stop = false;


        if (disabled == false)
        {
            if (/*xInput > 0.2f*/ Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                moving = true;
                GetComponent<SpriteRenderer>().flipX = false;
                //anim.Play("Run");

                anim.SetBool("run", true);
                anim.SetBool("idle", false);

                animTimer += Time.deltaTime;
            }
            else if (/*xInput < -0.2f*/ Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                moving = true;
                GetComponent<SpriteRenderer>().flipX = true;
                //  anim.Play("Run");

                anim.SetBool("run", true);
                anim.SetBool("idle", false);

                animTimer += Time.deltaTime;
            }
            else /*if(xInput == 0)*/
            {
                moving = false;

                anim.SetBool("idle", true);
                anim.SetBool("run", false);
            }

            scytheCount = Mathf.Clamp(scytheCount, 0, 3);
            initialPos = this.transform.position;

            xInput = Input.GetAxis("Horizontal");
            //cursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var allowedPos = mousePos - initialPos;
            allowedPos = Vector3.ClampMagnitude(allowedPos, 3f);
            cursor.transform.position = initialPos + allowedPos;

            isGrounded = Physics2D.OverlapBox(transform.position, GetComponent<CapsuleCollider2D>().size, 0, groundLayer);

            //    if(Input.GetMouseButton(0)) { }

            

            if (!pauseScript.isPaused)
            {
                if (Input.GetMouseButtonDown(0) && !isDashing && scytheCount > 0) // when throwing the scythe
                {
                    isLerping = false;
                    if (scytheCount > 0)
                    {
                        scytheSc.activate = true;
                        isDashing = true;
                    }
                    if (scytheCount == 0)
                    {
                        if (isGrounded)
                        {
                            scytheSc.activate = true;
                            isDashing = true;
                        }
                    }
                }
                else if (Input.GetMouseButtonDown(0) && isDashing) // after dashing
                {
                    isLerping = true;
                    scytheSc.stop = true;
                    scytheCount--;
                }

                if (Input.GetMouseButtonDown(1) && scytheSc2.finished == true) // when throwing the attack scythe
                {
                    scytheSc2.followPlayer = false;
                    scytheSc2.activate = true;
                }
                else
                {
                    scytheSc2.aim = true;
                }
            }
            if (isLerping)
            {
                rb.gravityScale = 0f;
                transform.position = Vector2.Lerp(transform.position, scythe.transform.position, 10 * Time.deltaTime);
                //use physics to move player towards scythe!!!!!!!!!!!!
            }
            else
            {
                //rb.gravityScale = Mathf.Lerp(0, 4.99f, 0.1f);
                rb.gravityScale = 4.99f;
            }
        }
        

    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(xInput * playerSpeed, rb.velocity.y); // lateral movement

        if (disabled)
        {
            rb.velocity = new Vector2(0f,0f);
            anim.Play("idle");
        }
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isLerping && collision.gameObject.tag == "collisonSprite")
        {
            print("aaaaa");
            rb.gravityScale = 4.99f;
            isLerping = false;
            scytheSc.followPlayer = true;
            scytheSc.aim = true;
            isDashing = false;
        }

        if (collision.gameObject.tag == "Dialogue")
        {

            if (Input.GetKey(KeyCode.E))
            {
                Dialogue.SetActive(true);
            }
        }
    }
}
