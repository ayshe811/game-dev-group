using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scytheScript : MonoBehaviour
{
    GameObject player;
    GameObject cursor;
    player playerScript;

    Rigidbody2D rb;
    Vector3 pos;
    Vector3 mousePos;
    public bool aim, isGrounded;
    public LayerMask groundLayer;

    public bool activate,followPlayer, hasThrown, finished;
   [SerializeField] float shootingForce;
    public float difX, difY, difXABS, difYABS;
    public float angleTan, angleBoard;
    public float coolDown;
    public Transform cursorTransform;

   public Animator anim;

    public bool stop;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        playerScript = GameObject.Find("player").GetComponent<player>();
        cursor = GameObject.Find("cursor");
        rb = GetComponent<Rigidbody2D>();
        cursorTransform = cursor.GetComponent<Transform>();
        activate = false;
        //shootingForce = 10f;  //NEEDS FINE TUNING (force for shooting scythe)
        aim = true;
        followPlayer = true;
        hasThrown = false;
        finished = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Physics2D.OverlapCircle(new Vector2(this.GetComponent<CircleCollider2D>().bounds.center.x,
        //    this.GetComponent<CircleCollider2D>().bounds.center.y),
        //    this.GetComponent<CircleCollider2D>().radius, 0, groundLayer)) isGrounded = true;

        Debug.DrawLine(cursor.transform.position, this.transform.position);
        if (aim == true)
        {
            difX = cursorTransform.position.x - transform.position.x;
            difY = cursorTransform.position.y - transform.position.y;
            angleTan = difX / difY;
            angleBoard = Mathf.Rad2Deg * Mathf.Atan(angleTan);
            if (difY < 0 && difX > 0) { angleBoard -= 180; }
            if (difY < 0 && difX < 0) { angleBoard -= 180; }
            angleBoard -= 90;
            transform.eulerAngles = transform.forward * -angleBoard;
        }

        if (stop) rb.velocity = Vector3.zero;
        if (activate) // when the player throws the scythe
        {
            followPlayer = false;
            rb.AddForce(shootingForce * transform.right, ForceMode2D.Impulse);
            aim = false;
            coolDown = 2f;
            hasThrown = true;
            finished = false;
            activate = false;
        }
        else //followPlayer = true;

        if (isGrounded)
        {
            followPlayer = true;
          //  playerScript.isDashing = false;
        }

        if (followPlayer) transform.position = player.transform.position;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "platform") isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
