using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    public int hitcount;

    public GameObject destroyedstatue;

    public SpriteRenderer spriterenderer;
    public Sprite StateOne;
    public Sprite StateTwo;
    public Sprite StateThree;
    public Sprite Destroyed;

    public GameObject rubbles;

    public float timer;

    public ParticleSystem rubble, rubble2;
    public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        destroyedstatue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hitcount == 1)
        {
            spriterenderer.sprite = StateTwo;
            //  rubble.Play();
        }

        if (hitcount == 2)
        {
            //   rubble.Play();


            timer += Time.deltaTime;


            if (timer > 0.2f)
            {
                spriterenderer.sprite = null;
                destroyedstatue.SetActive(true);
               // rubbles.SetActive(false);
            }
            if (timer > 0.8f)
            {
                spriterenderer.sprite = Destroyed;

                this.GetComponent<Collider2D>().enabled = false;

                timer = 2;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "scythe" && !isHit)
        {
            hitcount += 1;

            if (hitcount == 1) rubble.Play();
            else if (hitcount == 2) rubble2.Play();

            isHit = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "scythe")
        {
            isHit = false;
          //  print("bb");
        }
    }
}
