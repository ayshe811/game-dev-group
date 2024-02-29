using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public player playerScript;
    public GameObject player, teleportPlayer;

    public bool teleportMode, isTeleporting;
    public float teleportTimer;

    public bool isDashing;


    // Start is called before the first frame update
    void Start()
    {
        isDashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        teleportPlayer.transform.position = teleportPlayer.transform.position;

        if (Input.GetMouseButtonDown(0) && !isDashing) // dashing is false
        {
            //Instantiate(teleportPlayer, player.transform.position, Quaternion.identity);
            teleportPlayer.SetActive(true);
            teleportMode = true; // activates once the clone is instantiated
            isDashing = true;
        }
        else if (Input.GetMouseButtonDown(0) && isDashing) // dashing is true
        {
            player.transform.position = teleportPlayer.transform.position;
            teleportPlayer.transform.position = player.transform.position;
            teleportPlayer.SetActive(false);
            //Destroy (teleportPlayer.gameObject);
            isDashing = false;
            teleportMode = false;
        }



        if (teleportMode)
        {
            

            teleportTimer += Time.deltaTime;
            if (teleportTimer >= 2.5f)
            {
                teleportTimer = 0;
                teleportMode = false; // deactivates once the clone disappears
             //   player.transform.position = teleportPlayer.transform.position;
            }
        }
        
    }
}
