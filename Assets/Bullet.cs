using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //bulletSpeed = 10;
        rb.velocity = transform.up * bulletSpeed;
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
       // this.transform.position += new Vector3(0, 0.2f, 0);

    }
}
