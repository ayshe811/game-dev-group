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

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else Destroy(gameObject);
    //}
    public void startGame()
    {
        parSystem.Play();
        transitionAnim.SetTrigger("End");
       // NextLevel();
        //SceneManager.LoadScene("scene_1");
        //transitionAnim.SetTrigger("Start");
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
