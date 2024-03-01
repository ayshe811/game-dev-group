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

    public bool activate;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        cursor = GameObject.Find("cursor");
        rb = GetComponent<Rigidbody2D>();

        activate = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (activate)
        {
            transform.up = cursor.transform.position - transform.position;
            rb.velocity = transform.up * 10;
        }
        else 
        { 
            transform.position = player.transform.position;
           // cursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        }
    }
}
