using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    public int hitcount;

    public SpriteRenderer spriterenderer;
    public Sprite StateOne;
    public Sprite StateTwo;
    public Sprite StateThree;
    public Sprite Destroyed;

    public float timer;

    public ParticleSystem rubble;
    bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitcount == 1 && !isHit)
        {
            spriterenderer.sprite = StateTwo;
            rubble.Play();

            isHit = true;
        }

        if (hitcount == 2)
        {
            timer += Time.deltaTime;

            if (timer > 0.2f)
            {
                spriterenderer.sprite = StateThree;
            }
            if (timer > 0.4f)
            {
                spriterenderer.sprite = Destroyed;
                this.GetComponent<Collider2D>().enabled = false;
            }
        }      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "scythe")
        {
            hitcount += 1;
        } 
            
        
    }
}
