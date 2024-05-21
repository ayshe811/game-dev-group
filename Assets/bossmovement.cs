using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmovement : MonoBehaviour
{
    public Transform[] p1;


    public float speed = 0.1f;

    public Transform currentpos;

    public int i;

    
    // Start is called before the first frame update
    void Start()
    {
        currentpos= p1[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentpos.position, speed);

        if (this.transform.position == currentpos.position)
        {
            i++;
            currentpos = p1[i];

            if (currentpos == p1[5])
            {
                currentpos = p1[0];
                i= 0;
            }
        }
    }
}
