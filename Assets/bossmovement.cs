using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmovement : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    public Transform p3;
    public Transform p4;
    public Transform p5;
    public Transform p6;

    public float speed = 0.1f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = Vector2.Movetowards(transform.position, p1.position, speed);
    }
}
