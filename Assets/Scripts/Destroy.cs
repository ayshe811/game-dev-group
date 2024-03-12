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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitcount == 1)
        {
            spriterenderer.sprite = StateOne;
        }

        if (hitcount == 2)
        {
            spriterenderer.sprite = StateTwo;
        }

        if (hitcount == 3)
        {
            spriterenderer.sprite = StateThree;
        }

        if (hitcount == 4)
        {
            spriterenderer.sprite = Destroyed;
            this.GetComponent<Collider2D>().enabled = false;
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
