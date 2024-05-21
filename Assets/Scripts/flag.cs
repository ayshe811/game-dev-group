using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flag : MonoBehaviour
{
    public float timer;
    public bool end;

    public GameObject fadeinandout;
    [SerializeField] Animator transitionAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            timer += Time.deltaTime;

        }

        if (timer > 2) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            fadeinandout.SetActive(true);
            transitionAnim.SetTrigger("End");
            end= true;
        }
  
    }
}
