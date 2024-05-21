using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.WSA;

public class player : MonoBehaviour
{
    public int hp = 5;

    Rigidbody2D rb;
   [SerializeField] float xInput;
    float playerSpeed;
    public float timer, throwTimer;

    public GameObject scythe, cursor, scythe2;
    public scytheScript scytheSc;

    public bool isDashing, isLerping, moving,throwing;
    public scytheScript2 scytheSc2;
    
    public LayerMask groundLayer;
    public bool isGrounded, isThrown, isThrown2;
    SpriteRenderer playerSprite;

    public Animator anim;
    float animTimer;

    public GameObject Dialogue;

    public GameObject hpbar;

    Vector3 mousePos;
    Vector3 initialPos;

    public GameObject life;

    public bool disabled;
    public Sprite hp4;
    public Sprite hp3;
    public Sprite hp2;
    public Sprite hp1;
    public Sprite dashsprite, idleSprite;

    public bool hit = false;
    public float invince;
    public float deathtimer;
    // Start is called before the first frame update

    //I CANT SPELL
    void Start()
    {
        UnityEngine.Application.targetFrameRate = 60;

        rb = GetComponent<Rigidbody2D>();
        playerSpeed = 9;
        isDashing = false;
        scythe = GameObject.Find("ScytheParent");
        cursor = GameObject.Find("cursor");
        scytheSc=GameObject.Find("ScytheParent").GetComponent<scytheScript>();
        scytheSc2=GameObject.Find("ScytheParent2").GetComponent<scytheScript2>();
        playerSprite = GetComponent<SpriteRenderer>();
        throwing = false;

        playerSprite.sprite = idleSprite;

        //hpbar.GetComponent<Animator>().SetInteger("Health", (int)5);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SceneManager.LoadScene("scene_1");
        if (Input.GetKeyDown(KeyCode.Alpha2)) SceneManager.LoadScene("scene_2");
        if (Input.GetKeyDown(KeyCode.Alpha3)) SceneManager.LoadScene("scene_3");

        if (hit == true)
        {
            invince += Time.deltaTime;
            if (invince >= 1)
            {
                invince = 0f;
                hit = false;               
            }   
        }

        if (hp == 4 && hit == true)
        {
            //life.GetComponent<Image>().sprite = hp4;

            // hpbar.GetComponent<Animator>().Play("-2hp"); // - doesn't seem to be assigned in level 3!!!
            hpbar.GetComponent<Animator>().SetInteger("Health", 4);
            // - this seems logical?
        }

        if (hp == 3 && hit == true)
        {
            //life.GetComponent<Image>().sprite = hp3;
            hpbar.GetComponent<Animator>().SetInteger("Health", 3);
            
        }

        if (hp == 2)
        {
            //life.GetComponent<Image>().sprite = hp2;
            hpbar.GetComponent<Animator>().SetInteger("Health", 2);
        }

        if (hp == 1)
        {
            //life.GetComponent<Image>().sprite = hp1;
            hpbar.GetComponent<Animator>().SetInteger("Health", 1);
        }

        if (hp == 0)
        {
            hpbar.GetComponent<Animator>().SetInteger("Health", 0);
            deathtimer += Time.deltaTime;
            if (deathtimer >= 1.25f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (Physics2D.OverlapBox(new Vector2(this.GetComponent<BoxCollider2D>().bounds.center.x, 
            this.GetComponent<BoxCollider2D>().bounds.center.y), 
            this.GetComponent<BoxCollider2D>().size, 0, groundLayer)) isGrounded = true;

        else isGrounded = false;
        if (!isGrounded)
        {
            moving = false;

            //anim.SetBool("idle", true);
            //anim.SetBool("run", false);
        }
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
                GetComponent<SpriteRenderer>().flipX = false;
                if (isGrounded)
                {
                    moving = true;
                   
                    //anim.Play("Run");

                    //anim.SetBool("run", true);
                    //anim.SetBool("idle", false);

                    animTimer += Time.deltaTime;
                }
            }
            else if (/*xInput < -0.2f*/ Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<SpriteRenderer>().flipX = true;
                if (isGrounded)
                {
                    moving = true;
                  
                    //  anim.Play("Run");

                    //anim.SetBool("run", true);
                    //anim.SetBool("idle", false);

                    animTimer += Time.deltaTime;
                }
            }

            initialPos = this.transform.position;

            xInput = Input.GetAxis("Horizontal");
            //cursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var allowedPos = mousePos - initialPos;
            allowedPos = Vector3.ClampMagnitude(allowedPos, 3f);
            cursor.transform.position = initialPos + allowedPos;

            

            if (!pauseScript.isPaused)
            {
                if (rb.velocity.x >= 0.001f && !isThrown || rb.velocity.x <= -0.001f && !isThrown)
                {
                    anim.SetBool("run", true);
                    anim.SetBool("idle", false);
                }
                else if (rb.velocity.x == 0f && isThrown == false) /*if(xInput == 0)*/
                {
                    moving = false;

                    anim.SetBool("idle", true);
                    anim.SetBool("run", false);
                }

                if (Input.GetMouseButtonDown(0) && !isDashing) // when throwing the scythe
                {
                    playerSprite.sprite = idleSprite;
                    isThrown = true;
                    anim.SetBool("throw", true);
                    anim.SetBool("idle", false);
                    anim.SetBool("run", false);
                    
                    //if (throwTimer > 1)
                    //{
                    //    scytheSc.anim.SetBool("scythe", true);
                    //    isLerping = false;
                    //    if (isGrounded)
                    //    {
                    //        scytheSc.activate = true;
                    //        isDashing = true;
                    //    }

                    //   // throwTimer = 0;
                    //    anim.SetBool("throw", false);
                    //}
                }
                else if (Input.GetMouseButtonDown(0) && isDashing) // dashing
                {
                    GetComponent<SpriteRenderer>().sprite = dashsprite;
                    scytheSc.activate = false;
                    scytheSc.anim.SetBool("scythe", false);
                    isLerping = true;
                    rb.velocity = Vector2.zero;
                    scytheSc.stop = true;
                }

                if (isThrown) throwTimer += Time.deltaTime;
                if (throwTimer > 0.2f && isThrown)
                {
                    anim.SetBool("throw", true);
                    scytheSc.anim.SetBool("scythe", true);
                    isLerping = false;
                    if (isGrounded)
                    {
                        scytheSc.activate = true;
                        isDashing = true;
                    }

                    isThrown = false;
                    anim.SetBool("throw", false);
                   // anim.SetBool("wait", true);
                    throwTimer = 0;
                }

                if (Input.GetMouseButtonDown(1) && scytheSc2.finished == true) // when throwing the attack scythe
                {
                    anim.SetBool("throw", true);
                    anim.SetBool("idle", false);
                    anim.SetBool("run", false);
                    

                    isThrown2 = true;
                    

                    //scytheSc2.anim.SetBool("scythe", true);
                    //scytheSc2.followPlayer = false;
                    //scytheSc2.activate = true;
                }
                else if (scytheSc2.finished == false)
                {
                  //  scytheSc2.followPlayer = true;
                    scytheSc2.aim = true;
                    scytheSc2.anim.SetBool("scythe", false);
                }

                if (isThrown2) throwTimer += Time.deltaTime;

                if (throwTimer > 0.2f && isThrown2)
                {
                    scytheSc2.anim.SetBool("scythe", true);
                    scytheSc2.followPlayer = false;
                    scytheSc2.activate = true;

                    anim.SetBool("throw", false);
                    isThrown2 = false;
                    throwTimer = 0;
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
        if (isGrounded&&isLerping==false) 
        {
            rb.velocity = new Vector2(xInput * playerSpeed, rb.velocity.y); // lateral movement
        }
        else
        {
            //anim.SetBool("idle", true);
            //anim.SetBool("run", false);
            
        }//need to set falling animation when player is not grounded

        if (disabled)
        {
            anim.Play("idle");
            rb.velocity = new Vector2(0f,0f);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spike") SceneManager.LoadScene("scene_2");        
        if (collision.gameObject.tag == "death") SceneManager.LoadScene("scene_1");

        GameObject hpbar = GameObject.Find("HP");
        //   if (collision.gameObject.tag == "flag") SceneManager.LoadScene("scene_2");
        //   if (collision.gameObject.tag == "flag2") SceneManager.LoadScene("scene_3");

        if (collision.gameObject.tag == "Bullet" && hit == false)
        {
            hp--;
            print("///////" + hp);
            hit = true;
            //  hpbar.GetComponent<Animator>().SetBool("isHit", true);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    GameObject hpbar = GameObject.Find("HP");
    // //   if (collision.gameObject.tag == "flag") SceneManager.LoadScene("scene_2");
    // //   if (collision.gameObject.tag == "flag2") SceneManager.LoadScene("scene_3");

    //    if (collision.gameObject.tag == "Bullet" && hit == false)
    //    {
    //        hp--;
    //        print("///////" + hp);
    //        hit = true;
    //        //  hpbar.GetComponent<Animator>().SetBool("isHit", true);
    //    }
    //}
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
           // throwing = false;
        }

        if (collision.gameObject.tag == "Dialogue")
        {
            if (Input.GetKey(KeyCode.E))
            {
                anim.SetBool("run", false);
                xInput = 0;
                moving = false;
                anim.StopPlayback();                
                anim.SetBool("idle", true);
                Dialogue.SetActive(true);
            }
        }
       // if (collision.gameObject.tag == "Bullet") hit = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject hpbar = GameObject.Find("HP");
        if (collision.gameObject.tag == "Bullet")
        {
            //hit = false;
            life.GetComponent<Animator>().SetBool("isHit", false);
        }
    }
}
