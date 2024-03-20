using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour
{
    public GameObject pauseScreen, cursor;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) // temporary key input; subject to change.
        {
            if (!isPaused) pauseGame();
            else resumeGame();
        }
    }

    public void pauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    public void resumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void mainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void quit()
    {
        Application.Quit();
    }
}
