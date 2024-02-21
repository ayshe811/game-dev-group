using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public player playerScript;
    public GameObject player, teleportPlayer;

    public bool teleportMode, isTeleporting;
    public float teleportTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // TELEPORT
        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(teleportPlayer, player.transform.position, Quaternion.identity);
            teleportMode = true; // activates once the clone is instantiated
        }
        // TELEPORT

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
