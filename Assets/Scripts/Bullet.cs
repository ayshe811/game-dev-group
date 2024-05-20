using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ParticleSystem parSystem;
    public float bulletSpeed;
    Rigidbody2D rb;
    float fireTimer;
    bool collided;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //bulletSpeed = 10;
        rb.velocity = transform.up * bulletSpeed;
        Destroy(gameObject, 2f);
        parSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collided) fireTimer += Time.deltaTime;
        //if (fireTimer > 0.5f)
        //{
        //    Destroy(gameObject);
        //    fireTimer = 0;
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parSystem.Play();
            collided = true;


            Destroy(gameObject, 0.5f);
            sprite.enabled = false;
            //GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
