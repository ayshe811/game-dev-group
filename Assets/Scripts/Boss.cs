using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public bool phase1;
    public bool phase2;
    public bool phase3;

    public int bosslives = 20;
    public Slider bosshealth;

    public GameObject Head;
    public GameObject Arm1;
    public GameObject Arm2;

    public int timer;

    // Start is called before the first frame update
    void Start()
    {
        bosshealth.maxValue = 20;

        phase1 = true;
        phase2 = false;
        phase3 = false;
    }

    // Update is called once per frame
    void Update()
    {

        bosshealth.value = bosslives;

        

        if (phase1) 
        {
            
        }

        if (phase2)
        {

        }

        if (phase3)
        {

        }
    }

    
}
