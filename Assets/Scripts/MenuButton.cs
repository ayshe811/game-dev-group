using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public Sprite sprite;
    public Sprite clicked;
    public Sprite highlightSprite;

    public bool start;

    public float timer;

    void OnMouseOver()
    {
        transform.GetComponent<SpriteRenderer>().sprite = highlightSprite;
    }

    void OnMouseExit()
    {
        transform.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void OnMouseDown()
    {
        transform.GetComponent<SpriteRenderer>().sprite = clicked;

    }

    private void OnMouseUpAsButton()
    {
        start = true;
        transform.GetComponent<SpriteRenderer>().sprite = clicked;
    }

    private void Update()
    {
        if (start)
        {
            transform.GetComponent<SpriteRenderer>().sprite = clicked;
            timer += Time.deltaTime;
            if (timer > 0.2f)
            {
                SceneManager.LoadScene("scene_1");
            }
        }
    }
}
