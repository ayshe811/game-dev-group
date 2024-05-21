using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Dialogue2 : MonoBehaviour
{
    public GameObject continuebutt;
    public GameObject Player;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typespeed;

    public GameObject DialogueCamera;
    public GameObject DialogueCamera2;
    private void Start()
    {
        StartCoroutine(type());
        DialogueCamera.SetActive(true);
    }

    private void Update()
    {
        Player.GetComponent<player>().anim.SetBool("idle", true);

        if (textDisplay.text == sentences[index])
        {
            continuebutt.SetActive(true);
        }

        if (index == 1)
        {
            DialogueCamera2.SetActive(true);
        }
        //if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.E))
        //{
        //    nextsentence();
        //}
    }
    IEnumerator type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            continuebutt.SetActive(false);
            textDisplay.text += letter;
            yield return new WaitForSeconds(typespeed);
            continuebutt.SetActive(true);
        }
    }
    public void nextsentence()
    {

        if (index < sentences.Length - 1)
        {
            Player.GetComponent<player>().anim.SetBool("idle", true);
            index++;
            textDisplay.text = "";
            StartCoroutine(type());

        }
        else
        {
            Player.GetComponent<player>().Dialogue.SetActive(false);
            index = 0;
            DialogueCamera.SetActive(false);
            DialogueCamera2.SetActive(false);
        }
    }
}