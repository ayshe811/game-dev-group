using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float timer;
    public GameObject Bullet;
    

    // Start is called before the first frame update
    void Start()
    {
        Bullet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 2f)
        {
            Bullet.SetActive(true);
        }

        if (timer>= 3f)
        {
            Bullet.transform.position = this.transform.position;
            Bullet.SetActive(false);
            timer = 0f;
        }
    }
}
