using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Boss Boss;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Boss.phase1 == true)
        {
            if (collision.gameObject.tag == "scythe")
            {
                Boss.bosslives -- ;
            }
        }
    }
}
