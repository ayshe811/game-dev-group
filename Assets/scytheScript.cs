using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scytheScript : MonoBehaviour
{
    GameObject player;
    GameObject cursor;

    Rigidbody2D rb;
    Vector3 pos;
    Vector3 mousePos;
    public bool aim;

    public bool activate,followPlayer;
    public float shootingForce;
    public float difX, difY, difXABS, difYABS;
    public float angleTan, angleBoard;
    public Transform cursorTransform;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        cursor = GameObject.Find("cursor");
        rb = GetComponent<Rigidbody2D>();
        cursorTransform = cursor.GetComponent<Transform>();
        activate = false;
        //shootingForce = 10f;  //NEEDS FINE TUNING (force for shooting scythe)
        aim = true;
        followPlayer = true;
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


        if (activate)
        {
            followPlayer = false;
            rb.AddForce(shootingForce * transform.right, ForceMode2D.Impulse);
            aim=false;
            
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
    }
}
