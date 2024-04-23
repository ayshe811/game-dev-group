using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float timer;
    //public GameObject Bullet;


    public GameObject BulletPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
       // Bullet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //if(timer >= 2f)
        //{
        //    Bullet.SetActive(true);
        //}

        //if (timer>= 3f)
        //{
        //    Bullet.transform.position = this.transform.position;
        //    Bullet.SetActive(false);
        //    timer = 0f;
        //}

        //do instantiate and destroy

        if (timer >= 2f)
        {
          //  Bullet.SetActive(true);
          Instantiate(BulletPrefab, transform.position, transform.rotation);
            timer = 0;
        }


    }
}
