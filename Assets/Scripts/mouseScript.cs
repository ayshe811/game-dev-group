using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseScript : MonoBehaviour
{
    Vector3 mousePos;
    public player playerScript;
    public scytheScript scythe;
    // Update is called once per frame
    void Update()
    {
        // mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10); 
        // transform.position = mousePos;
    }
}
