using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scytheScript2 : MonoBehaviour
{
    GameObject player;
    GameObject cursor;
    player playerScript;

    public Sprite Circle;

    Rigidbody2D rb;
    Vector3 pos;
    Vector3 mousePos;
    public bool aim;

    public bool activate, followPlayer, hasThrown, finished;
    public float shootingForce;
    public float difX, difY, difXABS, difYABS;
    public float angleTan, angleBoard;
    public float coolDown;
    public Transform cursorTransform;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        playerScript = GameObject.Find("player").GetComponent<player>();
        cursor = GameObject.Find("cursor");
        rb = GetComponent<Rigidbody2D>();
        cursorTransform = cursor.GetComponent<Transform>();
        activate = false;
        shootingForce = 25f;  //NEEDS FINE TUNING (force for shooting scythe)
        aim = true;
        followPlayer = true;
        hasThrown = false;
        finished = true;
    }

    // Update is called once per frame
    void Update()
    {
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


        if (activate) // when the player throws the scythe
        {
            this.gameObject.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 1);
            followPlayer = false;
            rb.AddForce(shootingForce * transform.right, ForceMode2D.Impulse);
            aim = false;
            coolDown = 0.5f;
            hasThrown = true;
            finished = false;
            activate = false;
        }
      

        if (followPlayer)
        {
           transform.position = player.transform.position;
        }
        if (hasThrown && !finished) // if the player has thrown the scythe and the timer and the cool down period hasn't ended
        {
            coolDown -= Time.deltaTime;
            if (coolDown <= 0)
            {
                finished = true;
                print("ella");
                activate = false;
            }

        }

        if (finished == true)
        {
            followPlayer = true;
            this.GetComponent<SpriteRenderer>().sprite = Circle;            
        }
        else
        {
            followPlayer = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "statue")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color *= new Color(1, 1, 1, 0);
            anim.SetBool("scythe", false);
            finished = true;

            playerScript.isThrown2 = false;
            playerScript.throwTimer = 0;
           // coolDown = 0;
        }
    }
}
