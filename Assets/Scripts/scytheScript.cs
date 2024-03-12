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
    public bool aim;

    public bool activate,followPlayer, hasThrown, finished;
   [SerializeField] float shootingForce;
    public float difX, difY, difXABS, difYABS;
    public float angleTan, angleBoard;
    public float coolDown;
    public Transform cursorTransform;
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

        if (playerScript.isGrounded) shootingForce = 20f;
        else shootingForce = 7.5f;


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
        else 
        {
            
            // cursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        }
        if (followPlayer)
        {
            transform.position = player.transform.position;
            
        }
        if (hasThrown && !finished) // if the player has thrown the scythe and the timer and the cool down period hasn't ended
        {
            if (playerScript.scytheCount != 3)
            {
                coolDown -= Time.deltaTime;
                if (coolDown <= 0f)
                {
                    
                    if (playerScript.scytheCount == 2)
                    {
                        playerScript.scytheCount = 3;
                    }
                    if (playerScript.scytheCount == 1)
                    {
                        playerScript.scytheCount = 2;
                        coolDown = 2f;  
                    }
                    if (playerScript.scytheCount == 0)
                    {
                        playerScript.scytheCount = 1;
                        coolDown = 2f;
                    }
                }
            }
        }
    }
}
