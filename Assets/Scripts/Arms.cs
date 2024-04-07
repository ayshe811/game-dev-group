using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    public float attacktimer;
    public GameObject armfollow;
    public GameObject player;

    public Vector2 armpos;
    public Vector2 attackpos;
    public Vector2 startpos;

    public float attackspeed = 0.1f;
    public float followspeed = 0.5f;

    public bool reset;

    public bool p1;
    public bool p2;
    public bool p3;
    public bool p4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attacktimer += Time.deltaTime;

        if (attacktimer >= 3f)
        {
            p1 = true;
            p2 = false;
            p3 = false;
        }

        if (attacktimer >= 8.8f)
        {
            p1= false;
            p2 = true;
            p3 = false;
        }

        if (attacktimer >= 9f)
        {

            p1 = false;
            p2 = false;
            p3 = true;

        }

        if (p1 == true)
        {
            armpos = armfollow.transform.position;

            this.transform.position = Vector2.MoveTowards(this.transform.position, armfollow.transform.position, followspeed);
        }

        if (p2 == true)
        {
            attackpos = player.transform.position;
        }

        if (p3 == true)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, attackpos, attackspeed);
        }

    }
}
