using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class delete : MonoBehaviour
{
    public float timer;
    public bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            timer += Time.deltaTime;
            if (timer > 0.1)
            {
                Destroy(this.gameObject);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "death")
        {
            start = true;
            print("start");
            
        }
    }
}
