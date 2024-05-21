using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tooltip : MonoBehaviour
{
    public GameObject tooltipobj;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        tooltipobj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<player>().disabled == true)
        {
            tooltipobj.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tooltipobj.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tooltipobj.SetActive(false);
        }

    }
}
