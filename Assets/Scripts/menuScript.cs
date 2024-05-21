using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public ParticleSystem parSystem;
    [SerializeField] Animator transitionAnim;
    public static menuScript instance;
    public GameObject clouds;
    public float startTimer;
    public bool timerOn;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else Destroy(gameObject);
    //}

    void Start()
    {
        timerOn = false;
        startTimer = 0;
    }
    public void startGame()
    {
        timerOn=true;
        clouds.SetActive(true);
        parSystem.Play();


        
            
        
       // NextLevel();
        //SceneManager.LoadScene("scene_1");
        //transitionAnim.SetTrigger("Start");
    }
    private void Update()
    {if(timerOn) { startTimer += Time.deltaTime; }
        if (startTimer > 2.6f)
        {
            transitionAnim.SetTrigger("End");
        }
    }
    public void quitGame()
    {
        Application.Quit();
    }
    //public void NextLevel()
    //{
    //    StartCoroutine(LoadLevel());
    //}

    //IEnumerator LoadLevel()
    //{
    //    transitionAnim.SetTrigger("End");
    //    yield return new WaitForSeconds(1);
    //    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    //    transitionAnim.SetTrigger("Start");
    //}


    
}
